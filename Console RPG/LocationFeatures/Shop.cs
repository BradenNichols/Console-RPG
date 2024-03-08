using System;
using System.Collections.Generic;
using System.Threading;

namespace Console_RPG
{
    class Shop : LocationFeature
    {
        public string shopKeeperName;
        public string shopDescription;

        public List<Item> items;

        public Shop(string shopKeeperName, string shopDescription = "", List<Item> items = null) : base(false)
        {
            this.shopKeeperName = shopKeeperName;
            this.shopDescription = shopDescription;
            this.items = items;
        }

        public override void Resolve()
        {
            while (true)
            {
                Console.Clear();
                Program.PrintWithColor($"Welcome to {shopKeeperName}'s shop!\n{shopDescription}", ConsoleColor.DarkGreen);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nHere are my wares (Bank: {Player.coins}¢):");

                Console.ForegroundColor = ConsoleColor.Blue;
                Item result = Program.ChooseSomething(items, printClass: true, canExit: true);

                if (result is Item) // if we didnt exit
                {
                    if (result.shopPrice > Player.coins || Entity.random.Next(1, 100) <= 5)
                    {
                        Console.Clear();
                        Program.PrintWithColor("NO!", ConsoleColor.Red);
                    }
                    else
                    {
                        Player.coins -= result.shopPrice;
                        Program.PrintWithColor("YES! who shall have thee item?", ConsoleColor.Green);

                        Entity playerToGetIt = Program.ChooseSomething(Player.party);
                        playerToGetIt.backpack.Add(result);
                        items.Remove(result);

                        Program.PrintWithColor($"Gave {result.name} to {playerToGetIt.name}!", ConsoleColor.Green);
                        Thread.Sleep(1500);
                    }
                }
                else
                {
                    Console.Clear();
                    Program.PrintWithColor("BYE!", ConsoleColor.Red);

                    break;
                }
            }

            Thread.Sleep(1500);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
    }
}
