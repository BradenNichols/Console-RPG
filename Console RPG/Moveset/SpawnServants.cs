using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Servants : Move
    {
        public Servants() : base("Summon Servant")
        {
        }

        public override void Attack(Entity user, Entity target, Battle battle)
        {
            Console.WriteLine($"{user.name} summoned a servant to the battle!");

            battle.enemies.Add(battle.CreateEnemy("Duke's Servant"));
            battle.entityIndex++;
        }
    }
}
