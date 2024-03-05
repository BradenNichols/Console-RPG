using System;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

namespace Console_RPG
{
    class Player : Entity
    {
        public Player(string name, int maxhp = default, Stats stats = default) : base(name, maxhp, stats)
        {
        }

        public override string ChooseAction(List<string> choices)
        {
            Console.WriteLine("What would you like to do?");
            return Program.ChooseSomething<string>(choices);
        }

        public override Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("What item would you like to use?");
            return Program.ChooseSomething<Item>(choices);
        }

        public override Move ChooseMove(List<Move> choices)
        {
            Console.WriteLine("What move would you like to use?");
            return Program.ChooseSomething<Move>(choices);
        }

        public override Entity ChooseTarget(string moveName, List<Entity> choices)
        {
            // query the player
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Who would you like to use {moveName} on?");
            return Program.ChooseSomething<Entity>(choices);
        }
    }
}
