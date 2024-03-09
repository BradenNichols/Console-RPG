using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Vent : Move
    {
        private int defenseMin;
        private int defenseMax;

        public Vent(int minDamage = 1, int maxDamage = 2, int critChance = 0, int missChance = 30, int defenseMin = 7, int defenseMax = 15) : base("Vent", minDamage, maxDamage, critChance, missChance, true)
        {
            this.defenseMin = defenseMin;
            this.defenseMax = defenseMax;
        }

        public override void Attack(Entity user, Entity target, Battle battle)
        {
            int damage = (int)(Entity.random.Next(minDamage, maxDamage) * user.stats.dmgModifier);
            int defenseLower = Entity.random.Next(defenseMin, defenseMax);

            target.stats.defense -= defenseLower;
            Console.WriteLine($"{user.name} vented on {target.name}, lowering their defense by {defenseLower} (now {target.stats.defense} DEF).");

            target.Damage(damage);
        }
    }
}
