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
            //Console.WindowHeight = 50;
            Console.Title = "deepwoken";

            // Locations

            Location.StarterInn.SetNearbyLocations(north: Location.StarterSea);
            Location.StarterSea.SetNearbyLocations(north: Location.ErisiaShores);
            Location.ErisiaShores.SetNearbyLocations(east: Location.LowerErisia);

            Location.LowerErisia.SetNearbyLocations(east: Location.BanditCamp, north: Location.UpperErisia);
            Location.BanditCamp.SetNearbyLocations(east: Location.SharkoCave, north: Location.UpperErisia);
            Location.SharkoCave.SetNearbyLocations(east: Location.UpperErisia);

            Location.UpperErisia.SetNearbyLocations(east: Location.Gardens);
            Location.Gardens.SetNearbyLocations(south: Location.DukesManor);

            // Party

            Player.player1.moveset.Add(new Slash());
            Player.player1.moveset.Add(new Gambler());

            Slash gokuSlash = new Slash(critChance: Entity.random.Next(1, 5), minDamage: 10, maxDamage: 52);
            gokuSlash.name = "Epic Slash";

            Player.player2.moveset.Add(gokuSlash);
            Player.player2.moveset.Add(new Bounce());

            Player.player1.backpack.Add(new HealthPotion("Small Potion", healAmount: 35));

            Player.player2.backpack.Add(new HealthPotion("Goku Potion", healAmount: 90));
            Player.player2.backpack.Add(new HealthPotion("Small Potion", healAmount: 35));

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

            Player.hasManorKey = true;
            Player.coins = 75;
            Location.Gardens.Resolve();

            //Location.StarterInn.Resolve();

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

        public static T ChooseSomething<T>(List<T> choices, bool printClass = false, bool canExit = false)
        {
            foreach (T action in choices)
            {
                if (printClass == true)
                    Console.WriteLine(action);
                else
                    Console.WriteLine(GetNameOfT<T>(action));
            }

            if (canExit == true)
                Console.WriteLine("Exit");

            PrintWithColor("Input: ", ConsoleColor.DarkGray, newLine: false);

            while (true)
            {
                string choice = Console.ReadLine();

                if (choice.ToLower().Contains("exit"))
                    return default;

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
