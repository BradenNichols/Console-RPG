using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Gambler : Move
    {
        public Gambler(int minDamage = 6, int maxDamage = 12, int critChance = 100, int missChance = 40) : base("Gambler", minDamage, maxDamage, critChance, missChance)
        {
            
        }

        public override void Attack(Entity user, Entity target)
        {
            int damage = (int)(Entity.random.Next(minDamage, maxDamage) * user.stats.dmgModifier);

            if (RollForCrit() == true)
            {
                damage *= 8;
                Console.WriteLine($"{user.name} attacked {target.name} with {name} and landed a {damage} ({target.stats.defense} DEF) damage CRIT!");

                Thread.Sleep(1000);
            } else
                Console.WriteLine($"{user.name} attacked {target.name} with {name} and dealt {damage} ({target.stats.defense} DEF) damage!");

            target.Damage(damage);
        }
    }
}
