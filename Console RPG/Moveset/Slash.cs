using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Slash : Move
    {
        public Slash(int minDamage = 5, int maxDamage = 8) : base("Slash", minDamage, maxDamage)
        {
            
        }

        public override void Attack(Entity user, Entity target)
        {
            int damage = user.random.Next(minDamage, maxDamage);
            target.Damage(damage);

            Console.WriteLine($"{user.name} attacked {target.name} with {name} and took {damage} damage!");
        }
    }
}
