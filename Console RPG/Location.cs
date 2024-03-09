using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Location
    {
        // ETREAN SEA
        public static Location StarterInn = new Location(name: "Isle of Vigils", description: "A starting place for warriors.",
            featureType: "StarterInn");

        public static Location StarterSea = new Location(name: "Etrean Sea", description: "Something lurks in the waves..",
            featureType: "StarterSea");

        public static Location ErisiaShores = new Location(name: "Erisian Shores", description: "Shores to the Erisia Island.",
            featureType: "ErisiaShores");

        // ERISIA
        public static Location LowerErisia = new Location(name: "Lower Erisia", description: "A lost land, now made a battleground for warriors who know not why they fight.",
            featureType: "LowerErisia");

        public static Location BanditCamp = new Location(name: "Bandit Camp", description: "hmm i wonder if people are here",
            featureType: "BanditCamp");

        public static Location SharkoCave = new Location(name: "Unknown Cave", description: "...?",
            featureType: "SharkoCave");
        
        public static Location UpperErisia = new Location(name: "Upper Erisia", description: "The highest peaks of Erisia can be seen from anywhere.",
            featureType: "UpperErisia");

        public static Location Gardens = new Location(name: "Burning Stone Gardens", description: "Acid runs along the stones, giving way to a forest guarded by immortal giants.",
            featureType: "Gardens");

        public static Location DukesManor = new Location(name: "Strange Manor", description: "What was stolen from below lies within.", 
            featureType: "Manor");

        // Class

        public string name;
        public string description;

        public LocationFeature feature;
        public string featureType;

        public Location north, east, south, west;

        public Location(string name, string description = "", string featureType = "")
        {
            this.name = name;
            this.description = description;

            SetLocationFeature(featureType);
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {
            if (!(north is null))
            {
                this.north = north;
                north.south = this;
            }
 
            if (!(east is null))
            {
                this.east = east;
                east.west = this;
            }
                
            if (!(south is null))
            {
                this.south = south;
                south.north = this;
            }

            if (!(west is null))
            {
                this.west = west;
                west.east = this;
            }     
        }

        // Set Feature

        void SetLocationFeature(string featureType)
        {
            this.featureType = featureType;
            LocationFeature feature = null;

            if (featureType == "ErisiaShores")
            {
                List<string> enemies = new List<string>() { "Bandit", "Bandit" };

                if (Entity.random.Next(1, 100) <= 50)
                    enemies.Add("Bandit");

                feature = new Battle(enemies);
            }
            else if (featureType == "LowerErisia")
            {
                List<string> enemies = new List<string>() { "Bandit", "Bandit", "Strong Bandit" };
                feature = new Battle(enemies);
            }
            else if (featureType == "BanditCamp")
            {
                List<string> enemies = new List<string>() { "Gambler Bandit", "Strong Bandit" };
                feature = new Battle(enemies);
            }
            else if (featureType == "SharkoCave")
            {
                List<string> enemies = new List<string>() { "Sharko" };

                if (Entity.random.Next(1, 4) >= 2) // 25% chance for only 1 sharko
                    enemies.Add("Sharko");

                feature = new Battle(enemies);
            }
            else if (featureType == "Gardens")
            {
                List<Item> items = new List<Item>();
                items.Add(new HealthPotion("Good Potion", "Heals the target for 50hp", healAmount: 50, shopPrice: 10));
                items.Add(new HealthPotion("Funky Potion", "Too silly to describe", healAmount: Entity.random.Next(-20, 130), shopPrice: 10));
                
                items.Add(new SpeedArmor("Speed Suit", "+20 speed while equipped", shopPrice: 15, speedAmount: 20));

                if (Entity.random.Next(1, 2) == 1)
                    items.Add(new VigorArmor("Vigorous Jacket", "+25% death's door resist while equipped", shopPrice: 15, resistAmount: 25));
                else
                    items.Add(new DefenseArmor("Heavy Mech", "+8 defense while equipped", shopPrice: 15, defenseAmount: 8));

                items.Add(new Hivelords("Hivelords Hubris", "1.4x DMG while equipped", shopPrice: 20));
                items.Add(new TheButton(name: "The Button", description: "???", shopPrice: 20));

                feature = new Shop("Derek", "Got any derek dollars?", items);
            } 
            else if (featureType == "Manor")
            {
                feature = new Manor();
            }

            this.feature = feature;
        }

        // Resolve

        public void Resolve()
        {
            Program.PrintWithColor($"--- {name} ---\n{description}\n", ConsoleColor.Yellow);
            Thread.Sleep(2000);

            if (!(feature is null))
            {
                Program.PrintWithColor("It seems there is something here..", ConsoleColor.DarkYellow);
                Thread.Sleep(2000);

                feature.Resolve();

                if (feature.lostGame == true || feature.noResolve == true)
                    return;

                if (featureType == "SharkoCave" && Player.hasManorKey == false)
                {
                    Program.PrintWithColor("You check your pocket and notice a mysterious key..", ConsoleColor.DarkRed);
                    Player.hasManorKey = true;

                    Thread.Sleep(3000);
                    Console.Clear();
                }
            }

            List<string> choices = new List<string>();

            if (!(north is null))
                choices.Add("NORTH: " + north.name);

            if (!(east is null))
                choices.Add("EAST: " + east.name);

            if (!(south is null))
                choices.Add("SOUTH: " + south.name);

            if (!(west is null))
                choices.Add("WEST: " + west.name);

            string Direction = Program.ChooseSomething<string>(choices);
            Location nextLocation = null;

            if (Direction.Contains("NORTH"))
                nextLocation = north;
            else if (Direction.Contains("EAST"))
                nextLocation = east;
            else if (Direction.Contains("SOUTH"))
                nextLocation = south;
            else if (Direction.Contains("WEST"))
                nextLocation = west;

            nextLocation.Resolve();
        }
    }
}














//ඞ