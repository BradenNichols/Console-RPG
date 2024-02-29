using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main()
        {
            Console.CursorSize = 100;
            Console.Title = "actual peak";

            // Players

            Player derek = new Player("Derek", maxhp: 30, 
                new Stats(defense: 6, speed: 0, debuffResist: 20, deathResist: Entity.random.Next(10, 95), dodgeChance: Entity.random.Next(10, 35)));
            
            Player jaden = new Player("Jaden", maxhp: 60, 
                new Stats(defense: 10, speed: 3, debuffResist: 40, deathResist: Entity.random.Next(40, 70), dodgeChance: Entity.random.Next(2, 20)));

            // AI

            AI duke = new AI("Duke Erisia", maxhp: 500, new Stats(defense: 0, speed: -5, debuffResist: 50, deathResist: 0, dodgeChance: Entity.random.Next(5, 15)));
            AI wawawawawa = new AI("the button", maxhp: 1, new Stats(defense: 10, speed: 2, debuffResist: 0, deathResist: 0, dodgeChance: Entity.random.Next(50, 60)));

            // Items

            HealthPotion potion1 = new HealthPotion("Potion1", "one", 10, 5);
            HealthPotion potiondead = new HealthPotion("Potiondead", "two", 20, 5, 2, -20);

            Vigor vigor1 = new Vigor("invigorating", "mhm", 50, 30, 4, 15);

            /*
            Location meow = new Location("car", "mew");
            Location wawawa = new Location("idk", "in the land");

            meow.SetNearbyLocations(south: wawawa);*/

            derek.moveset.Add(new Slash());
            jaden.moveset.Add(new Slash());

            duke.moveset.Add(new Slash(minDamage: 12, maxDamage: 30, critChance: 20));
            wawawawawa.moveset.Add(new Slash(critChance: 80));

            List<Entity> party = new List<Entity>() { derek, jaden };
            List<Entity> enemies = new List<Entity>() { duke, wawawawawa };
            
            Battle test = new Battle(party, enemies);
            test.StartBattle();
        }
    }
}
