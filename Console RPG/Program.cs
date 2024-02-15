using System;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Player Apple = new Player("Apple", hp: 100, mana: 100, new Stats(speed: 90, strength: 60, defense: 50), buff: 50, heal: 50);
            Ally Cavity = new Ally("Cavity", 50, 50, new Stats(200, 40, 80), 10, 50);
            Player PrincessAgave  = new Player("Princess Agave", 200, 200, new Stats(60, 100, 50), 10, 500);
            Enemy DragonFruit = new Enemy("Drago the Dragon Fruit", 500, 250, new Stats(100, 100, 100), 30, 500);
            Enemy ToothAche = new Enemy("Toothache", 60, 60, new Stats(10, 50, 70), 5, 50);
            Enemy KingCookie = new Enemy("King Cookie", 150, 150, new Stats(70, 70, 70), 50, 1000);

            VitaminItem VitaminC = new VitaminItem(shopPrice: 50, maxAmount: 30, "Vitamin C", "This is some Vitamin C! It'll boost your Immune System... totally...", healAmount: 50, vitaminAmount:1); ;
            SugarItem ChocolateBar = new SugarItem(50, 30, "Chocolate Bar", "This Bar isn't made of Candy people... surely not?", 50, 1);
            SugarItem LegendaryCookie = new SugarItem(100, 10, "Legendary Cookie", "These Cookies are very tasty! There is nothing wrong with them! AT ALL...", 100, 2);
            VitaminItem Vitalizer = new VitaminItem(100, 10, "Vitalizer", "It supposedly should give you extra vitality... why do people like it so much?", 100, 2);
            CookieItem Cookie = new CookieItem(500, 2, "Cookie", "These cookies are razor sharp. Sharp enough to kill anything...", 500, 100);
            CookieItem BurntCookie = new CookieItem(1000, 1, "Burnt Cookie", "This is a burnt cookie. DON'T BUY IT! I'M SERIOUS!", 1000, 1);

            Location CandyCastle = new Location("The Candy Castle", "King Cookie's castle. A place... that has been corrupted. The candy people here are not happy.");
            Location RotLair = new Location("The Rot Lair", "A lair of pure evil and corruption. The \"root\" of all evil. We should probably not be here yet.");
            Location FruitLand = new Location("Fruitland", "A land that can resist the corruption. Full of fruit people like you.");
            Location TheLink = new Location("The Link", "The center of the world, where the lands meet. And where your journey ends.");
            Location HardHouse = new Location("Apple's House", "The start of the journey. A place of happy memories that has not been corrupted yet.");
            

            TheLink.SetNearbyLocations(north: CandyCastle, west: RotLair, south: HardHouse, east: FruitLand);
            RotLair.SetNearbyLocations(north: CandyCastle, east: TheLink, south: HardHouse);
            CandyCastle.SetNearbyLocations(south: TheLink, west: RotLair, east: FruitLand);
            FruitLand.SetNearbyLocations(north: CandyCastle, east: TheLink, south: HardHouse);
            HardHouse.SetNearbyLocations(north: TheLink, east: FruitLand, west: RotLair);

            HardHouse.Resolve();
        }
    }
}
