using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main()
        {
            Console.CursorSize = 100;
            Console.WindowHeight = 50;
            Console.Title = "the new mario and luigi rpg game";

            // Players

            Player lapis = new Player("Lapis", maxhp: 20, 
                new Stats(defense: Entity.random.Next(2, 8), speed: 0, debuffResist: 20, deathResist: Entity.random.Next(1, 85), dodgeChance: Entity.random.Next(1, 70)));
            
            Player goku = new Player("Goku", maxhp: 800, 
                new Stats(defense: Entity.random.Next(-180, -50), speed: 25, debuffResist: 40, deathResist: Entity.random.Next(80, 95), dodgeChance: Entity.random.Next(1, 2)));

            // AI

            AI duke = new AI("Duke Erisia", maxhp: 500, new Stats(defense: 0, speed: -5, debuffResist: 50, deathResist: 0, dodgeChance: Entity.random.Next(5, 15))); // L L haha hah ah a L
            AI wawawawawa = new AI("the button", maxhp: 1, new Stats(defense: 10, speed: 26, debuffResist: 0, deathResist: 0, dodgeChance: Entity.random.Next(40, 50)));

            // Items

            HealthPotion potion1 = new HealthPotion("Potion1", "one", 10, 5);
            HealthPotion potiondead = new HealthPotion("Potiondead", "two", 20, 5, 2, -20);

            Vigor vigor1 = new Vigor("invigorating", "mhm", 50, 30, 4, 15);

            /*
            Location meow = new Location("car", "mew");
            Location wawawa = new Location("idk", "in the land");

            meow.SetNearbyLocations(south: wawawa);*/

            lapis.moveset.Add(new Slash());
            lapis.moveset.Add(new Gambler());

            goku.moveset.Add(new Slash(critChance: 0, maxDamage: 52));

            duke.moveset.Add(new Slash(minDamage: 6, maxDamage: 30, critChance: 20));
            wawawawawa.moveset.Add(new Slash(critChance: 75));

            List<Entity> party = new List<Entity>() { lapis, goku };
            List<Entity> enemies = new List<Entity>() { duke, wawawawawa };
            
            Battle test = new Battle(party, enemies);
            test.StartBattle();
        }
    }
}
