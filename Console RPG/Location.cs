using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public static Location CandyCastle = new Location("The Candy Castle", "King Cookie's castle. A place... that has been corrupted. The candy people here are not happy.", new Battle(new List<Enemy>() { Enemy.CandySoldier, Enemy.KingCookie, Enemy.CandyKnight}));
        public static Location RotLair = new Location("The Rot Lair", "A lair of pure evil and corruption. The \"root\" of all evil. We should probably not be here yet.", new Battle(new List<Enemy>() { Enemy.Cavitee, Enemy.ToothAche, Enemy.Hole }));
        public static Location FruitLand = new Location("Fruitland", "A land that can resist the corruption. Full of fruit people like you.");
        public static Location TheLink = new Location("The Link", "The center of the world, where the lands meet. And where your journey ends.");
        public static Location HardHouse = new Location("Apple's House", "The start of the journey. A place of happy memories that has not been corrupted yet.");

        public string name;
        public string description;
        public Battle battle;

        public Location north, east, south, west;

        public Location(string name, string description, Battle battle = null)
        {
            this.battle = battle;
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
        public void Resolve(List<Player> entities, List<Ally> allies)
        {
            battle?.Resolve(entities, allies);

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
                this.Resolve(entities, allies);
            }
            nextLocation.Resolve(entities, allies);
        }
    }
}
