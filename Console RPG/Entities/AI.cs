using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class AI : Entity
    {
        public AI(string name, int maxhp = default, Stats stats = default) : base(name, maxhp, stats)
        {
            
        }

        public override Move ChooseMove(List<Move> choices)
        {
            Random random = new Random();
            return choices[random.Next(0, choices.Count)];
        }

        public override Entity ChooseTarget(Move move, List<Entity> choices)
        {
            Random random = new Random();
            return choices[random.Next(0, choices.Count)];
        }
    }

    // Have different types of enemies / allies that inherit from AI
}
