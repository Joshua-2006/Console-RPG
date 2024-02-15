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
            Console.WriteLine("You find yourself in " + this.name + ".");
            Console.WriteLine(this.description);
            Console.WriteLine("Type one of the following directions: NORTH, EAST, WEST, SOUTH");

            if (!(north is null))
                Console.WriteLine("NORTH: " + this.north.name);

            if (!(east is null))
                Console.WriteLine("EAST: " + this.east.name);

            if (!(south is null))
                Console.WriteLine("SOUTH: " + this.south.name);

            if (!(west is null))
                Console.WriteLine("WEST: " + this.west.name);

            string direction = Console.ReadLine();
            Location nextLocation = null;

            if (direction == "NORTH")
                nextLocation = this.north;
            else if (direction == "EAST")
                nextLocation = this.east;
            else if (direction == "SOUTH")
                nextLocation = this.south;
            else if (direction == "WEST")
                nextLocation = this.west;
            else
            {
                Console.WriteLine("Try again.");
                this.Resolve();
            }
            nextLocation.Resolve();
        }
    }
}
