using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("So you're the god of this world, huh?");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("My friend needs your help.");
            System.Threading.Thread.Sleep(1000);
            Location.TheLink.SetNearbyLocations(north: Location.CandyCastle, east: Location.FruitLand, south: Location.HardHouse, west: Location.RotLair);
            Location.CandyCastle.SetNearbyLocations(east: Location.FruitLand, south: Location.TheLink, west: Location.RotLair);
           Location.FruitLand.SetNearbyLocations(north: Location.CandyCastle, south: Location.HardHouse, west: Location.TheLink);
           Location.RotLair.SetNearbyLocations(north: Location.CandyCastle, east: Location.TheLink, south: Location.HardHouse); 
            Location.HardHouse.SetNearbyLocations(north: Location.TheLink, east: Location.FruitLand, west: Location.RotLair);

            Location.HardHouse.Resolve(new List<Player>() {Player.Apple, Player.PrincessAgave}, new List<Ally> {Ally.Cavity });
            

        }
       
    }
}
