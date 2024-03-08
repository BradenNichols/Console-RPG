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
        public int missChance;

        protected Move(string name, int minDamage, int maxDamage, int critChance = 0, int missChance = 0)
        {
            this.name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.critChance = critChance;
            this.missChance = missChance;
        }

        public override string ToString()
        {
            string Value = name;
            Value += $": {minDamage}-{maxDamage} DMG | {critChance}% CRIT";

            if (missChance > 0)
                Value += $" | {missChance}% MISS";

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
