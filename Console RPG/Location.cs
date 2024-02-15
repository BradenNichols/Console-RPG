using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public string name;
        public string description;

        public Location north, east, south, west;

        public Location(string name, string description)
        {
            this.name = name;
            this.description = description;
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

            if (!(north is null))
                Console.WriteLine("NORTH: " + north.name);

            if (!(east is null))
                Console.WriteLine("EAST: " + east.name);

            if (!(south is null))
                Console.WriteLine("SOUTH: " + south.name);

            if (!(west is null))
                Console.WriteLine("WEST: " + west.name);

            string Direction = Console.ReadLine().ToLower();
            Location nextLocation = null;

            if (Direction == "north")
                nextLocation = north;
            else if (Direction == "east")
                nextLocation = east;
            else if (Direction == "south")
                nextLocation = south;
            else if (Direction == "west")
                nextLocation = west;

            nextLocation.Resolve();
        }
    }
}
