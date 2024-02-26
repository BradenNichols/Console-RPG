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

        public Random rand;

        public Move(string name, int minDamage, int maxDamage)
        {
            this.name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;

            rand = new Random();
        }

        public abstract void Attack(Entity user, Entity target);
    }
}
