using System;
using System.Collections.Generic;
using System.Text;

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
        public Random random;

        public List<Move> moveset;
        public List<Item> backpack;
        
        public Entity(string name, int maxhp = 100, Stats stats = new Stats(), List<Move> moveset = null, List<Item> backpack = null)
        {
            this.name = name;
            this.health = maxhp;
            this.maxHealth = maxhp;

            this.onDeathsDoor = false;
            this.isDead = false;

            this.stats = stats;
            this.random = new Random();
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

        public abstract Move ChooseMove(List<Move> choices);
        public abstract Entity ChooseTarget(Move move, List<Entity> choices);

        // Non-Abstract Functions
        
        public void Attack(Entity target, Move move)
        {
            move.Attack(this, target);
        }

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }

        // Damage

        public void Damage(int amount)
        {
            health = Math.Clamp(health - amount, 0, maxHealth);

            if (health == 0)
            {
                if (onDeathsDoor == false && stats.deathResist > 0)
                    onDeathsDoor = true;
                else if (onDeathsDoor == true)
                {
                    int result = random.Next(1, 100);

                    if (result > stats.deathResist)
                        Kill();
                    else
                        stats.deathResist = Math.Clamp(stats.deathResist - 5, 0, 100);
                }
                else
                    Kill();
            }
        }

        void Kill()
        {
            onDeathsDoor = false;
            isDead = true;
            health = 0;
        }
    }
}
