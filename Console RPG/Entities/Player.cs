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

        string GetNameOfT<T>(T thing)
        {
            string name = "";

            if (thing is Entity)
                name = (thing as Entity).name;
            else if (thing is Move)
                name = (thing as Move).name;
            else if (thing is Item)
                name = (thing as Item).name;
            else if (thing is string)
                name = (string)(object)thing;

            return name;
        }

        T ChooseSomething<T>(List<T> choices)
        {
            foreach (T action in choices)
            {
                if (action is Move)
                    Console.WriteLine(action);
                else
                    Console.WriteLine(GetNameOfT<T>(action));
            }

            Entity.PrintWithColor("Input: ", ConsoleColor.DarkGray, newLine: false);

            while (true)
            {
                string choice = Console.ReadLine();

                foreach (T action in choices)
                {
                    string name = GetNameOfT<T>(action);

                    if (name.ToLower().Contains(choice.ToLower()))
                    {
                        Console.WriteLine("");
                        return action;
                    }
                }

                Console.WriteLine("Not a valid choice. Please pick again.");
                Entity.PrintWithColor("Input: ", ConsoleColor.DarkGray, newLine: false);
            }
        }

        public override string ChooseAction(List<string> choices)
        {
            Console.WriteLine("What would you like to do?");
            return ChooseSomething<string>(choices);
        }

        public override Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("What item would you like to use?");
            return ChooseSomething<Item>(choices);
        }

        public override Move ChooseMove(List<Move> choices)
        {
            Console.WriteLine("What move would you like to use?");
            return ChooseSomething<Move>(choices);
        }

        public override Entity ChooseTarget(string moveName, List<Entity> choices)
        {
            // query the player
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Who would you like to use {moveName} on?");
            return ChooseSomething<Entity>(choices);
        }
    }
}
