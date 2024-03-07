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
            Console.WriteLine("His name is Apple. He is a courageous apple that tries his best to befriend everyone.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("He has two friends, Princess Agave and Cavity.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Princess Agave is the pure and kind Princess of the Candy Kingdom!");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("And Cavity is a cunning and cool thief of the Rot Lair.");
            System.Threading.Thread.Sleep(1000);
            Location.TheLink.SetNearbyLocations(north: Location.CandyCastle, east: Location.FruitLand, south: Location.HardHouse, west: Location.RotLair);
            Location.CandyCastle.SetNearbyLocations(south: Location.TheLink);
            Location.FruitLand.SetNearbyLocations(west: Location.TheLink);
            Location.RotLair.SetNearbyLocations(east: Location.TheLink); 
            Location.HardHouse.SetNearbyLocations(north: Location.TheLink);

            Location.HardHouse.Resolve(new List<Player>() {Player.Apple, Player.PrincessAgave}, new List<Ally> {Ally.Cavity });
            
            
        }
       
    }
}
