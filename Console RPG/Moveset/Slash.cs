using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Slash : Move
    {
        public Slash(int minDamage = 8, int maxDamage = 29, int critChance = 12) : base("Slash", minDamage, maxDamage, critChance)
        {
            
        }

        public override void Attack(Entity user, Entity target)
        {
            int damage = Entity.random.Next(minDamage, maxDamage);

            if (RollForCrit() == true)
            {
                damage *= 3;
                Console.WriteLine($"{user.name} attacked {target.name} with {name} and landed a {damage} damage CRIT!");

                Thread.Sleep(1000);
            } else
                Console.WriteLine($"{user.name} attacked {target.name} with {name} and dealt {damage} damage!");

            target.Damage(damage);
        }
    }
}
