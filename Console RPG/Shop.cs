using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Text;

namespace Console_RPG
{
     class Shop : LocationEvent
    {
        public string ownerName;
        public string shopName;
        public List<Item> items;
        public string dialogue;
        public string moredialogue;

        public Shop(string ownerName, string shopName, List<Item> items, string dialogue, string moredialogue) : base(false)
        {
            this.ownerName = ownerName;
            this.shopName = shopName;
            this.items = items;
            this.dialogue = dialogue;
            this.moredialogue = moredialogue;
        }
        public override void Resolve(List<Player> players, List<Ally> allies)
        {
            Console.WriteLine($"Welcome to {ownerName}'s shop...");

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine($"This shop {shopName} is interesting...");

            System.Threading.Thread.Sleep(1000);
            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("BUY, STEAL, LEAVE, SELL, TRY TO UNALIVE");
                string userInput = Console.ReadLine();
                if (userInput == "BUY")
                {
                    Item item = ChooseItem(this.items);
                    
                    if (Player.MONEY < item.shopPrice)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Try to come back later when you have some money.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (Player.MONEY >= item.shopPrice)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Player.MONEY -= item.shopPrice;
                        Player.Inventory.Add(item);
                        Console.WriteLine($"You got a {item.name}.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.WriteLine("Too bad you wasted time.");
                }
                else if (userInput == "STEAL")
                {
                    Item item = ChooseItem(this.items);
                    Player.Inventory.Add(item);
                    Console.WriteLine($"You stole an {item.name}.");
                    if (item.shopPrice > 1)
                    {
                        Console.WriteLine("Well... now you die.");
                    }
                    new Battle(new List<Enemy> { Enemy.TheBonder });
                }
                else if (userInput == "LEAVE")
                {
                    break;
                }
                else if (userInput == "TRY TO UNALIVE")
                {
                    new Battle(new List<Enemy> {Enemy.TheBonder});
                    
                }
                else if (userInput == "SELL")
                {
                    Item item = ChooseItem(Player.Inventory);
                    Player.MONEY += item.shopPrice;
                    Player.Inventory.Remove(item);
                }
                else
                {
                    Console.WriteLine("You just wasted all of that time dang...");
                    System.Threading.Thread.Sleep(10000);
                    Console.WriteLine("Well you waited... why?");
                }
            }
            Console.WriteLine("Well now... BYE-");

        }
        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Which item would you like to buy or sell?");
            // Iterate through each choice.
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1} : {choices[i].name} (*{choices[i].shopPrice})");
            }
            // Let user pick choice.
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
    }
    
}
