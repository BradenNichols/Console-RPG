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
                Program.PrintWithColor($"({shopKeeperName})\nHey, welcome to my shop.\n{shopDescription}", ConsoleColor.DarkGreen);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nThis is all I've got left. (Player Bank: {Player.coins}¢)");

                Console.ForegroundColor = ConsoleColor.Blue;
                Item result = Program.ChooseSomething(items, printClass: true, canExit: true);

                if (result is Item) // if we didnt exit
                {
                    if (result.shopPrice > Player.coins)
                    {
                        Program.PrintWithColor("\nNO! ur too broke", ConsoleColor.Red);
                        Thread.Sleep(1500);
                    }
                    else
                    {
                        Player.coins -= result.shopPrice;
                        Program.PrintWithColor("OF COURSE! Who shall have thee item?", ConsoleColor.DarkGreen);

                        Entity playerToGetIt = Program.ChooseSomething(Battle.GetValid(Player.party));
                        items.Remove(result);

                        if (result is Equipment)
                            playerToGetIt.Equip((Equipment)result);
                        else
                            playerToGetIt.backpack.Add(result);

                        Program.PrintWithColor($"Gave {result.name} to {playerToGetIt.name}!", ConsoleColor.Green);
                        Thread.Sleep(1500);
                    }
                }
                else
                {
                    Console.Clear();
                    Program.PrintWithColor("You may have a chance to stand up to him..", ConsoleColor.DarkGreen);

                    break;
                }
            }

            Thread.Sleep(2500);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
    }
}
