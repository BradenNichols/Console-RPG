using System;
using System.Collections.Generic;
using System.Threading;

namespace Console_RPG
{
    class Manor : LocationFeature
    {
        public Manor() : base(false)
        {
            noResolve = true;
        }

        public override void Resolve()
        {
            Console.Clear();

            Program.PrintWithColor("You are confronted with a locked door.", ConsoleColor.DarkMagenta);
            Thread.Sleep(2000);
            Program.PrintWithColor("Do you proceed?\n", ConsoleColor.DarkMagenta);

            Thread.Sleep(1500);

            string result = Program.ChooseSomething(new List<string>() { "Unlock the door.", "Leave." });

            if (result.ToLower().Contains("leave"))
            {
                Console.ResetColor();
                Console.Clear();

                Location.UpperErisia.Resolve();
            } else
            {
                if (Player.hasManorKey == false)
                {
                    Program.PrintWithColor("You check your pockets, realizing theres no key on you.\nPerhaps explore around more?\n", ConsoleColor.DarkGray);
                    Thread.Sleep(2500);

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Program.ChooseSomething(new List<string>() { "Leave." });

                    Console.ResetColor();
                    Console.Clear();

                    Location.UpperErisia.Resolve();
                } else
                {
                    Console.Clear();
                    Thread.Sleep(1500);

                    Program.PrintWithColor("An ominous feeling reverberates through the halls of the manor.", ConsoleColor.DarkRed);
                    Thread.Sleep(3000);
                    Program.PrintWithColor("At the end of a journey, there is always something left.", ConsoleColor.DarkRed);

                    Thread.Sleep(3000);
                    Program.PrintWithColor("\nYour time has come to an end.", ConsoleColor.DarkMagenta);

                    Thread.Sleep(4000);
                    Console.Clear();

                    // Battle

                    foreach(Entity entity in Player.party)
                    {
                        entity.health = entity.maxHealth;
                    }

                    Battle dukeBattle = new Battle(new List<string> { "Duke Erisia" });
                    dukeBattle.Resolve();

                    if (dukeBattle.lostGame == true)
                        return;

                    Console.Clear();

                    Program.PrintWithColor("You win!! You took down the great Duke Erisia, congrats", ConsoleColor.DarkCyan);
                    Thread.Sleep(3000);
                }
            }
        }
    }
}
