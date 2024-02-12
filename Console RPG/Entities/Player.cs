using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Player : Entity
    {
        public Player(string name, int maxhp = default, Stats stats = default) : base(name, maxhp, stats)
        {

        }

        public override Entity ChooseTarget(List<Entity> choices)
        {
            // query the player
            return choices[0];
        }
    }
}
