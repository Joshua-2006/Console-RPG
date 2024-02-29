using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Player : Entity
    {
        public static List<Item> Inventory = new List<Item>();

         public static Player Apple = new Player("Apple", hp: 100, mana: 100, new Stats(speed: 90, strength: 60, defense: 50), buff: 50, heal: 50);
         public static Player PrincessAgave = new Player("Princess Agave", 200, 200, new Stats(60, 100, 50), 10, 500);
       
        public int buff;
        public int heal;
        public Player(string name, int hp, int mana, Stats stats, int buff, int heal) : base(name, hp, mana, stats)
        {
            this.buff = buff;
            this.heal = heal;
        }
        public void Buff(Player target)
        {
             Stats stats = target.stats;
            int buffs = stats.strength += stats.defense + stats.strength;
            int buffy = stats.strength += buffs;
            Console.WriteLine(target.name + " had buffed themself for " + buffs + " and gained that much attack!");
        }
        public override Entity ChooseTarget(List<Entity> choices)
        {
            Console.WriteLine("It's time to fight! Choose the number of an enemy you would like to fight!");
            // Iterate through each choice.
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1} : {choices[i].name}");
            }
            // Let user pick choice.
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("It's time to fight! Choose the number of an item you would like to use!");
            // Iterate through each choice.
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1} : {choices[i].name}");
            }
            // Let user pick choice.
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
        public override void Attack(Entity target)
        {
            Console.WriteLine(this.name + " attacked " + target.name + "!");
            
        }
        public override void DoTurn(List<Player> players, List<Ally> allies, List<Enemy> enemies)
        {
            Console.WriteLine($"You can choose to ATTACK or USE ITEM");
           string choice = Console.ReadLine();
            if (choice == "ATTACK")
            {
            Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
            Attack(target);
            }
            else if(choice == "USE ITEM") 
            {
                Item item = ChooseItem(Inventory);
                Console.WriteLine("Would you like to use an ITEM on an ENEMY or a PLAYER");
                if (choice == "ENEMY")
                {
                    Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                    item.Use(this, target);
                    Inventory.Remove(item);
                }
                else if (choice == "PLAYER")
                {
                    Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                    item.Use(this, target);
                    Inventory.Remove(item);
                }
              else
               {
                    Console.WriteLine("TOO BAD");
               }
                
            }
            else
            {
                Console.WriteLine("DON'T DO THAT AGAIN!");
                DoTurn(players, allies, enemies);
            }
            
        }
    }
}
