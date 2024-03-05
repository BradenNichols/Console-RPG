using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main()
        {
            // Setup

            Console.CursorSize = 100;
            Console.WindowHeight = 50;
            Console.Title = "deepwoken";

            // Party

            Player lapis = new Player("Lapis", maxhp: 20, 
                new Stats(defense: Entity.random.Next(2, 8), speed: 0, debuffResist: 20, deathResist: Entity.random.Next(1, 85), dodgeChance: Entity.random.Next(1, 70)));
            
            Player goku = new Player("Goku", maxhp: 800, 
                new Stats(defense: Entity.random.Next(-180, -50), speed: 25, debuffResist: 40, deathResist: Entity.random.Next(80, 95), dodgeChance: Entity.random.Next(1, 2)));

            lapis.moveset.Add(new Slash());
            lapis.moveset.Add(new Gambler());

            goku.moveset.Add(new Slash(critChance: 0, maxDamage: 52));

            List<Entity> party = new List<Entity>() { lapis, goku };

            // AI
            /*

            AI duke = new AI("Duke Erisia", maxhp: 500, new Stats(defense: 0, speed: -5, debuffResist: 50, deathResist: 0, dodgeChance: Entity.random.Next(5, 15))); // L L haha hah ah a L
            AI wawawawawa = new AI("the button", maxhp: 1, new Stats(defense: 10, speed: 26, debuffResist: 0, deathResist: 0, dodgeChance: Entity.random.Next(40, 50)));
            
           duke.moveset.Add(new Slash(minDamage: 6, maxDamage: 30, critChance: 20));
            wawawawawa.moveset.Add(new Slash(critChance: 75));
             
            */
            // Items
            /*
            HealthPotion potion1 = new HealthPotion("Potion1", "one", 10);
            HealthPotion potiondead = new HealthPotion("Potiondead", "two", -20);
            */

            /*
            Location meow = new Location("car", "mew");
            Location wawawa = new Location("idk", "in the land");

            meow.SetNearbyLocations(south: wawawa);*/

            /*
            List<Entity> enemies = new List<Entity>() { duke, wawawawawa };
            
            Battle test = new Battle(party, enemies);
            test.StartBattle();*/

            // Actual Gameplay

            Location.StarterInn.Resolve();

        }

        // Helpers

        public static string GetNameOfT<T>(T thing)
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

        public static T ChooseSomething<T>(List<T> choices)
        {
            foreach (T action in choices)
            {
                if (action is Move)
                    Console.WriteLine(action);
                else
                    Console.WriteLine(GetNameOfT<T>(action));
            }

            PrintWithColor("Input: ", ConsoleColor.DarkGray, newLine: false);

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
                PrintWithColor("Input: ", ConsoleColor.DarkGray, newLine: false);
            }
        }

        public static void PrintWithColor(string Text, ConsoleColor color, bool newLine = true)
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            Console.ForegroundColor = color;

            if (newLine == true)
                Console.WriteLine(Text);
            else
                Console.Write(Text);

            Console.ForegroundColor = prevColor;
        }
    }
}
