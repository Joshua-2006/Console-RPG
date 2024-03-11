using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public static Location CandyCastle = new Location("The Candy Castle", "King Cookie's castle. A place... that has been corrupted. The candy people here are not happy.", new Battle(new List<Enemy>() { Enemy.CandySoldier, Enemy.KingCookie, Enemy.CandyKnight}));
        public static Location RotLair = new Location("The Rot Lair", "A lair of pure evil and corruption. The \"root\" of all evil. We should probably not be here yet.", new Battle(new List<Enemy>() { Enemy.Cavitee, Enemy.ToothAche, Enemy.Hole }));
        public static Location FruitLand = new Location("Fruitland", "A land that can resist the corruption. Full of fruit people like you.", new Battle(new List<Enemy>() { Enemy.DragonFruit }));
        public static Location TheLink = new Location("The Link", "The center of the world, where the lands meet. And where your journey ends.", new Shop("The Bonder", "Fate's Atlas", new List<Item>() { CookieItem.Cookie, CookieItem.BurntCookie, SugarItem.LegendaryCookie, SugarItem.ChocolateBar, VitaminItem.VitaminC, VitaminItem.Vitalizer, Armor.CandyCap, Weapon.SwordOfAttorneys }, "You have quite the journey ahead of you, don't you?", "Perhaps your journey shall end happily."));
        public static Location HardHouse = new Location("Apple's House", "The start of the journey. A place of happy memories that has not been corrupted yet.");
        public static Location TheJohn = new Location("The Janitorial Closet", "The closet in Apple's house.");
        public static Location PokePelago = new Location("The Poke Pelago", "What is a Pokemon thing doing here?", new Battle(new List<Enemy>() { Enemy.Pokemon, Enemy.Pokemon1, Enemy.Pokemon2 }));
        public static Location TheCourtroom = new Location("The Courtroom", "It feels like OBJECTION was yelled here a lot.", new Battle(new List<Enemy>() { Enemy.PhoenixWright}));
        public static Location TheFinalDestination = new Location("The Final Destination", "It is legitimately the FINAL destination or is it.", new Shop("The Bonder", "Fate's Atlas", new List<Item>() { CookieItem.Cookie, CookieItem.BurntCookie, SugarItem.LegendaryCookie, SugarItem.ChocolateBar, VitaminItem.VitaminC, VitaminItem.Vitalizer, Armor.CandyCap, Weapon.SwordOfAttorneys }, "You have quite the journey ahead of you, don't you?", "Perhaps your journey shall end happily."));
        public static Location SkyLands = new Location("Skylands", "OMG ARE THOSE SKYLANDERS!?!? Oh you killed them... dang.", new Battle(new List<Enemy>() { Enemy.Skylander, Enemy.Skylander1, Enemy.Skylander2 }));
        public static Location DereksHouse = new Location("Derek's House", "How do you feel about being in your own house Derek?");
        public static Location GhoulsOfChaos = new Location("The Ghouls of Chaos", "Well here's our final stop.", new Battle(new List<Enemy>() { Enemy.Jax, Enemy.Andrew, Enemy.Ethan, Enemy.Toby}));

        public string name;                                                                                                                                                                              
        public string description;                                                                                                                                                                       
        public LocationEvent POI;                                                                                                                                                                        

        public Location north, east, south, west;

        public Location(string name, string description,LocationEvent POI = null)
        {
            this.POI = POI;
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
            if (this == GhoulsOfChaos)
            {
                Console.WriteLine("You've encountered the Ghouls of Chaos. Well now it's time to fight.");
            }
            if (this == TheFinalDestination)
            {
                Console.WriteLine("You can enter SUPERHEAL and SUPERBUFF to do a lot more.");
            }
           
            POI?.Resolve(entities, allies);
            if (this == GhoulsOfChaos)
            {
                Console.WriteLine("You defeated the Ghouls of Chaos. Congratulations. Now LEAVE PLEASE I BEG YOU!");
                System.Environment.Exit(0);
            }
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
