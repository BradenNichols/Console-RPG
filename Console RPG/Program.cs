using System;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Player derek = new Player("Derek", maxhp: 30, new Stats(defense: 0, speed: -4, debuffResist: 20, deathResist: 65, dodgeChance: 50));
            Player jaden = new Player("Jaden", maxhp: 150, new Stats(defense: 6, speed: -10, debuffResist: 40, deathResist: 80, dodgeChance: 6));

            AI jackson = new AI("Jackson", maxhp: 50, new Stats(defense: 1, speed: 4, debuffResist: 15, deathResist: 25, dodgeChance: 25));
            AI button = new AI("the button", maxhp: 1, new Stats(defense: 100, speed: 2, debuffResist: 0, deathResist: 0, dodgeChance: 95));

            bool[] ranks = { true };

            Console.WriteLine(derek.stats.deathResist);
        }
    }
}
