using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Moveset
{
    abstract class Move
    {
        public string name;

        public int minDamage;
        public int maxDamage;

        public bool[] ranks;

        public Move(string name, int minDamage, int maxDamage, bool[] ranks = null)
        {
            this.name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;

            this.ranks = ranks ?? new bool[4];
        }

        public void Attack(Entity user, Entity target)
        {
            Console.WriteLine(user.name + " attacked " + target.name + " with " + name + "!");
        }
    }
}
