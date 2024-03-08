using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    abstract class Entity
    {
        public string name;
        public int health, maxHealth;

        public bool onDeathsDoor;
        public bool isDead;

        // Composition

        public Stats stats;
        public static Random random = new Random();

        public List<Move> moveset;
        public List<Item> backpack;

        public Equipment weapon;
        public List<Equipment> armor;
        
        protected Entity(string name, int maxhp = 50, Stats stats = new Stats(), List<Move> moveset = null, List<Item> backpack = null)
        {
            this.name = name;
            this.health = maxhp;
            this.maxHealth = maxhp;

            this.onDeathsDoor = false;
            this.isDead = false;

            this.stats = stats;

            this.moveset = moveset ?? new List<Move>();
            this.backpack = backpack ?? new List<Item>();
        }

        // Overrides

        public override string ToString()
        {
            string Value = $"{name}\n";
            
            if (isDead == true)
            {
                Value += "DEAD";
                return Value;
            }

            Value += $"Health: {health} / {maxHealth}";

            if (onDeathsDoor == true)
                Value += $" (DEATH'S DOOR: {stats.deathResist}%)";

            Value += $"\n{stats.defense} DEF | {stats.speed} SPD | {stats.dodgeChance}% DODGE";

            return Value;
        }

        // Abstract Functions

        public abstract string ChooseAction(List<string> choices);
        public abstract Item ChooseItem(List<Item> choices);
        public abstract Move ChooseMove(List<Move> choices);
        public abstract Entity ChooseTarget(string moveName, List<Entity> choices);

        // Non-Abstract Functions
        
        public void Attack(Entity target, Move move)
        {
            if (Entity.random.Next(1, 100) <= move.missChance)
            {
                Program.PrintWithColor($"The attack {move.name} MISSED {target.name}! ({move.missChance}%)", ConsoleColor.DarkGray);
                return;
            } 
            else if (Entity.random.Next(1, 100) <= target.stats.dodgeChance)
            {
                Program.PrintWithColor($"{target.name} dodged {move.name}.. ({target.stats.dodgeChance}%)", ConsoleColor.DarkGreen);
                return;
            } 

            move.Attack(this, target);
        }

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
            backpack.Remove(item);
        }

        public void Equip(Equipment equipment)
        {
            if (equipment.equipmentType == "Armor")
            {
                equipment.Use(this, this);
                armor.Add(equipment);
            } else if (equipment.equipmentType == "Weapon")
            {
                if (!(weapon is null))
                    weapon.Use(this, this);

                weapon.Use(this, this);
                weapon = equipment;
            }
        }

        // HP Stuff
        
        public void Heal(int amount)
        {
            if (isDead == true)
                return;

            health = Math.Clamp(health + amount, 0, maxHealth);
            Console.WriteLine($"Healed {name} {amount} HP, bringing them to {health} HP.");

            if (health > 0 && onDeathsDoor == true)
            {
                onDeathsDoor = false;

                Thread.Sleep(1000);
                Program.PrintWithColor($"{name} is no longer on Death's Door!", ConsoleColor.DarkGreen);
            }
        }

        public void Damage(int amount)
        {
            amount -= stats.defense;

            if (amount <= 0)
                return;

            health = Math.Clamp(health - amount, 0, maxHealth);

            if (health == 0)
            {
                if (onDeathsDoor == false && stats.deathResist > 0)
                {
                    onDeathsDoor = true;
                    Thread.Sleep(1000);
                    Program.PrintWithColor($"{name} is now on Death's Door!", ConsoleColor.DarkRed);
                } else if (onDeathsDoor == true)
                {
                    Program.PrintWithColor($"\nRolling chance to survive.. ({stats.deathResist}%)", ConsoleColor.DarkRed);
                    Thread.Sleep(2000);

                    int result = Entity.random.Next(1, 100);

                    if (result > stats.deathResist)
                        Kill();
                    else
                    {
                        stats.deathResist = Math.Clamp(stats.deathResist - 10, 0, 100);
                        Program.PrintWithColor($"{name} survived..", ConsoleColor.DarkCyan);
                    }
                } else
                    Kill();
            }
        }

        void Kill()
        {
            onDeathsDoor = false;
            isDead = true;
            health = 0;

            Thread.Sleep(1000);
            Program.PrintWithColor($"{name} died.", ConsoleColor.Red);
        }
    }
}
