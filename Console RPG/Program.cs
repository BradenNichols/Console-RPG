using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorSize = 100;
            Console.Title = "actual peak";

            Player derek = new Player("Derek", maxhp: 30, new Stats(defense: 0, speed: 0, debuffResist: 20, deathResist: 65, dodgeChance: 50));
            Player jaden = new Player("Jaden", maxhp: 150, new Stats(defense: 6, speed: 3, debuffResist: 40, deathResist: 80, dodgeChance: 6));

            AI jackson = new AI("Jackson", maxhp: 50, new Stats(defense: 1, speed: 5, debuffResist: 15, deathResist: 25, dodgeChance: 25));
            AI button = new AI("the button", maxhp: 1, new Stats(defense: 100, speed: 2, debuffResist: 0, deathResist: 0, dodgeChance: 95));

            HealthPotion potion1 = new HealthPotion("Potion1", "one", 10, 5);
            HealthPotion potiondead = new HealthPotion("Potiondead", "two", 20, 5, 2, -20);

            //derek.UseItem(potion1, jackson);
            //button.UseItem(potion1, jackson);

            Vigor vigor1 = new Vigor("invigorating", "mhm", 50, 30, 4, 15);
            //jaden.UseItem(vigor1, derek);

            /*
            Location meow = new Location("car", "mew");
            Location wawawa = new Location("idk", "in the land");

            meow.SetNearbyLocations(south: wawawa);*/

            derek.moveset.Add(new Slash());
            jaden.moveset.Add(new Slash());

            jackson.moveset.Add(new Slash());
            button.moveset.Add(new Slash());

            List<Entity> party = new List<Entity>() { derek, jaden };
            List<Entity> enemies = new List<Entity>() { jackson, button };
            
            Battle test = new Battle(party, enemies);
            test.BeginRound();
        }
    }
}
