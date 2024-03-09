using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Button : Move
    {
        public Button(int minDamage = 1, int maxDamage = 2, int critChance = 2, int missChance = 15) : base("Push Button", minDamage, maxDamage, critChance, missChance)
        {
            
        }

        public override void Attack(Entity user, Entity target, Battle battle)
        {
            int damage = (int)(Entity.random.Next(minDamage, maxDamage) * user.stats.dmgModifier);

            if (RollForCrit() == true)
            {
                Console.WriteLine($"{user.name} HIT THE BUTTON AND {target.name} COLLAPSED.");
                damage = target.health + target.stats.defense;

                if (target.onDeathsDoor == true)
                    target.stats.deathResist = 0;

                Thread.Sleep(1000);
            } else
            {
                critChance += 1;
                Console.WriteLine($"{user.name} hit the button on {target.name}. \nYou feel the buttons' power growing..");
            }

            target.Damage(damage);
        }
    }
}
