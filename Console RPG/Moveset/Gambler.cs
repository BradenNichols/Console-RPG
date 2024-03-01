using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Gambler : Move
    {
        public Gambler(int minDamage = 6, int maxDamage = 12, int critChance = 80, int missChance = 40) : base("Gambler", minDamage, maxDamage, critChance, missChance)
        {
            
        }

        public override void Attack(Entity user, Entity target)
        {
            int damage = Entity.random.Next(minDamage, maxDamage);

            if (RollForCrit() == true)
            {
                damage *= 8;
                Console.WriteLine($"{user.name} attacked {target.name} with {name} and landed a {damage} damage CRIT!");

                Thread.Sleep(1000);
            } else
                Console.WriteLine($"{user.name} attacked {target.name} with {name} and dealt {damage} damage!");

            target.Damage(damage);
        }
    }
}
