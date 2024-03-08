using System;
using System.Collections.Generic;
using System.Threading;

namespace Console_RPG
{
    class AI : Entity
    {
        public AI(string name, int maxhp = default, Stats stats = default, List<Move> moveset = null, List<Item> backpack = null) : base(name, maxhp, stats, moveset, backpack)
        {
            
        }

        public override string ChooseAction(List<string> choices)
        {
            return "Attack";
        }
        public override Item ChooseItem(List<Item> choices)
        {
            Thread.Sleep(1500 * (Entity.random.Next(14, 20) / 10));
            return choices[Entity.random.Next(0, choices.Count)];
        }

        public override Move ChooseMove(List<Move> choices)
        {
            Thread.Sleep(1500 * (Entity.random.Next(14, 20) / 10));
            return choices[Entity.random.Next(0, choices.Count)];
        }

        public override Entity ChooseTarget(string moveName, List<Entity> choices)
        {
            return choices[Entity.random.Next(0, choices.Count)];
        }
    }
}
