using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Location.TheLink.SetNearbyLocations(north: Location.CandyCastle, east: Location.FruitLand, south: Location.HardHouse, west: Location.RotLair);
            Location.CandyCastle.SetNearbyLocations(east: Location.FruitLand, south: Location.TheLink, west: Location.RotLair);
           Location.FruitLand.SetNearbyLocations(north: Location.CandyCastle, south: Location.HardHouse, west: Location.TheLink);
           Location.RotLair.SetNearbyLocations(north: Location.CandyCastle, east: Location.TheLink, south: Location.HardHouse); 
            Location.HardHouse.SetNearbyLocations(north: Location.TheLink, east: Location.FruitLand, west: Location.RotLair);

            Location.HardHouse.Resolve(new List<Player>() {Player.Apple}, new List<Ally> { });
            Location.CandyCastle.Resolve(new List<Player>() {Player.Apple, Player.PrincessAgave}, new List<Ally> { });

            
        }
       
    }
}
