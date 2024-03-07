using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    class Location
    {
        // ETREAN SEA
        public static Location StarterInn = new Location(name: "Isle of Vigils", description: "A starting place for warriors.",
            north: StarterSea, featureType: "StarterInn");

        public static Location StarterSea = new Location(name: "Etrean Sea", description: "Something lurkes in the waves..",
            north: ErisiaShores, south: StarterInn, featureType: "StarterSea");

        public static Location ErisiaShores = new Location(name: "Erisian Shores", description: "Shores to the Erisia Island.",
            east: LowerErisia, south: StarterSea, featureType: "ErisiaShores");

        // ERISIA
        public static Location LowerErisia = new Location(name: "Lower Erisia", description: "A land lost, now made a battleground for warriors know not why they fight.",
            east: BanditCamp, north: UpperErisia, west: ErisiaShores, featureType: "LowerErisia");

        public static Location BanditCamp = new Location(name: "Bandit Camp", description: "hmm i wonder if people are here",
            east: SharkoCave, west: LowerErisia, north: UpperErisia, featureType: "BanditCamp");

        public static Location SharkoCave = new Location(name: "Unknown Cave", description: "...?",
            east: UpperErisia, west: BanditCamp, featureType: "SharkoCave");
        
        public static Location UpperErisia = new Location(name: "Upper Erisia", description: "lalalalala",
            east: Gardens, west: SharkoCave, featureType: "UpperErisia");

        public static Location Gardens = new Location(name: "Burning Stone Gardens", description: "lalalalala",
            south: DukesManor, north: UpperErisia);

        public static Location DukesManor = new Location(name: "Strange Manor", description: "lalalalala",
            south: HisRoom, north: Gardens);

        public static Location HisRoom = new Location(name: "???", description: "lalalalala",
            north: Gardens);

        // Class

        public string name;
        public string description;
        public LocationFeature feature;

        public Location north, east, south, west;

        public Location(string name, string description = "", string featureType = "", Location north = null, Location east = null, Location south = null, Location west = null)
        {
            this.name = name;
            this.description = description;

            SetLocationFeature(featureType);
            SetNearbyLocations(north, east, south, west);
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {
            this.north = north;
            this.east = east;
            this.south = south;
            this.west = west;

            if (!(north is null))
                north.south = this;

            if (!(east is null))
                east.west = this;

            if (!(south is null))
                south.north = this;

            if (!(west is null))
                west.east = this;
        }

        // Set Feature

        void SetLocationFeature(string featureType)
        {
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
            } else if (featureType == "BanditCamp")
            {
                List<string> enemies = new List<string>() { "Gambler Bandit", "Strong Bandit" };
                feature = new Battle(enemies);
            } else if (featureType == "UpperErisia")
            {
                List<Item> items = new List<Item>() { new HealthPotion("Good Potion", healAmount: 50, shopPrice: 15) };
                items.Add(new HealthPotion("Funky Potion", healAmount: Entity.random.Next(-20, 70), shopPrice: 10));

                feature = new Shop("Derek", "hey man whats up queso", items);
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