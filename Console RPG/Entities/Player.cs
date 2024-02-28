using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Player : Entity
    {
        public Player(string name, int maxhp = default, Stats stats = default) : base(name, maxhp, stats)
        {

        }

        public override Move ChooseMove(List<Move> choices)
        {
            Console.WriteLine("What move would you like to use?");

            foreach (Move move in choices)
            {
                Console.WriteLine(move.name);
            }

            while (true)
            {
                string choice = Console.ReadLine();

                foreach (Move move in choices)
                {
                    if (choice.ToLower() == move.name.ToLower())
                    {
                        return move;
                    }
                }

                Console.WriteLine("Not a valid move. Please pick again.");
            }
        }

        public override Entity ChooseTarget(Move move, List<Entity> choices)
        {
            // query the player
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Who would you like to attack with {move.name}?");

            foreach (Entity entity in choices)
            {
                if (entity.isDead == false)
                    Console.WriteLine(entity.name);
            }

            while (true)
            {
                string choice = Console.ReadLine();

                foreach (Entity entity in choices)
                {
                    if (choice.ToLower() == entity.name.ToLower() && entity.isDead == false)
                    {
                        return entity;
                    }
                }

                Console.WriteLine("Not a valid enemy. Please pick again.");
            }
        }
    }
}
