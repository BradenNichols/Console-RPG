using Console_RPG.BaseClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        // ETREAN SEA
        public static Location StarterInn = new Location(name: "Isle of Vigils", description: "lalalalala",
            north: StarterSea);

        public static Location StarterSea = new Location(name: "Etrean Sea", description: "lalalalala",
            north: ErisiaShores, south: StarterInn);

        public static Location ErisiaShores = new Location(name: "Erisian Shores", description: "lalalalala",
            east: LowerErisia, south: StarterSea);

        // ERISIA
        public static Location LowerErisia = new Location(name: "Lower Erisia", description: "lalalalala",
            east: BanditCamp, north: UpperErisia, west: ErisiaShores);

        public static Location BanditCamp = new Location(name: "Bandit Camp", description: "lalalalala",
            east: SharkoCave, west: LowerErisia, north: UpperErisia);

        public static Location SharkoCave = new Location(name: "Unknown Cave", description: "lalalalala",
            east: UpperErisia, west: BanditCamp);
        
        public static Location UpperErisia = new Location(name: "Upper Erisia", description: "lalalalala",
            east: Gardens, west: SharkoCave);

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

        public Location(string name, string description = "", LocationFeature feature = null, Location north = null, Location east = null, Location south = null, Location west = null)
        {
            this.name = name;
            this.description = description;
            this.feature = feature;
        
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

        public void Resolve()
        {
            Console.WriteLine("You find yourself in " + name + ": " + description);

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
