using System;
using System.Collections.Generic;
using System.Threading;

namespace Console_RPG
{
    class AI : Entity
    {
        public AI(string name, int maxhp = default, Stats stats = default) : base(name, maxhp, stats)
        {
            
        }

        public override string ChooseAction(List<string> choices)
        {
            return "Attack";
        }

        public override Move ChooseMove(List<Move> choices)
        {
            Thread.Sleep(1500 * (Entity.random.Next(14, 20) / 10));
            return choices[Entity.random.Next(0, choices.Count)];
        }

        public override Entity ChooseTarget(Move move, List<Entity> choices)
        {
            return choices[Entity.random.Next(0, choices.Count)];
        }
    }

    // Have different types of enemies / allies that inherit from AI
}
