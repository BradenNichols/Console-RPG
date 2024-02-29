using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Move
    {
        public string name;

        public int minDamage;
        public int maxDamage;
        public int critChance;

        public Move(string name, int minDamage, int maxDamage, int critChance = 0)
        {
            this.name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.critChance = critChance;
        }

        public override string ToString()
        {
            string Value = name;
            Value += $": {minDamage}-{maxDamage} DMG | {critChance}% CRIT";

            return Value;
        }

        public abstract void Attack(Entity user, Entity target);
        public bool RollForCrit()
        {
            if (Entity.random.Next(1, 100) <= critChance)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;

                return true;
            }

            return false;
        }
    }
}
