using System;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;
using System.Drawing;

namespace Console_RPG
{
    class Player : Entity
    {
        public static Player player1 = new Player("Nick from L4D2", maxhp: 75,
            new Stats(defense: Entity.random.Next(2, 8), speed: Entity.random.Next(3, 12), debuffResist: 20, deathResist: Entity.random.Next(1, 85), dodgeChance: Entity.random.Next(1, 70)));

        public static Player player2 = new Player("Goku", maxhp: 750,
            new Stats(defense: Entity.random.Next(-50, -20), speed: 15, debuffResist: 40, deathResist: Entity.random.Next(80, 95), dodgeChance: Entity.random.Next(1, 2)));

        public static List<Entity> party = new List<Entity> { player1, player2 };

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
