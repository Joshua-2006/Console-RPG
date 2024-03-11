using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Console_RPG
{
    class Player : Entity
    {
        public static List<Item> Inventory = new List<Item>() { };
        public static int MONEY = 0;

        public static Player Apple = new Player("Apple", hp: 100, mana: 100, new Stats(speed: 90, strength: 100, defense: 100), buff: 100, heal: 100);
        public static Player Elppa = new Player("Apple", hp: 100, mana: 100, new Stats(speed: 90, strength: 100, defense: 100), buff: 100, heal: 100);
        public static Player PrincessAgave = new Player("Princess Agave", 200, 200, new Stats(60, 150, 150), 500, 500);
        public static Player EvagaSsecnirp = new Player("Princess Agave", 200, 200, new Stats(60, 150, 150), 500, 500);

        public int buff;
        public int heal;
        public Player(string name, int hp, int mana, Stats stats, int buff, int heal) : base(name, hp, mana, stats)
        {
            this.buff = buff;
            this.heal = heal;
        }
        public void Buff(Entity target)
        {

            int buff = target.stats.strength += target.stats.strength + this.buff;
            Console.WriteLine($"{target.name} had buffed themself for {buff} and now has {target.stats.strength}!");
        }
        public void SUPERBUFF(Entity target)
        {
            int buffs = target.stats.strength * this.buff;
            Console.WriteLine($"{target.name} was buffed for {buffs} and now has {target.stats.strength}");
        }
        public void Heal(Entity target)
        {
            int HPRegained = target.currentHP += this.heal + this.stats.strength;
            Console.WriteLine($"{target.name} healed for {HPRegained} and now has {target.currentHP} amount of HP!");
        }
        public void SUPERHeal(Entity target)
        {
            int HPR = target.currentHP = this.heal * this.stats.strength;
            Console.WriteLine($"{target.name} healed for {HPR} and now has {target.currentHP} amount of HP!");
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
            string userInput = Console.ReadLine();
            int index = Convert.ToInt32(userInput);
            return choices[index - 1];
        }
        public override void Attack(Entity target)
        {
            int damage = this.stats.strength - target.stats.defense;
            int hp = target.currentHP -= damage;
            Console.WriteLine($"{this.name} attacked {target.name} for {damage} amount! {target.name} has {hp} amount of hp now!");
        }
        public override void DoTurn(List<Player> players, List<Ally> allies, List<Enemy> enemies)
        {
            Console.WriteLine($"You can choose to ATTACK, USE ITEM, HEAL, BUFF, or STATS");
            string choice = Console.ReadLine();
            if (choice == "ATTACK")
            {
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                Attack(target);
            }
            else if (choice == "USE ITEM")
            {
                Item item = ChooseItem(Inventory);
                Console.WriteLine("Would you like to use an ITEM on an ENEMY, PLAYER, or ALLY");
                choice = Console.ReadLine();
                if (choice == "ENEMY")
                {
                    Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                    item.Use(this, target);
                    Inventory.Remove(item);
                }
                else if (choice == "PLAYER")
                {
                    Entity target = ChooseTarget(players.Cast<Entity>().ToList());
                    item.Use(this, target);
                    Inventory.Remove(item);
                }
                else if (choice == "ALLY")
                {
                    Entity target = ChooseTarget(allies.Cast<Entity>().ToList());
                    item.Use(this, target);
                    Inventory.Remove(item);
                }
                else
                {
                    Console.WriteLine("TOO BAD");
                }

            }
            else if (choice == "BUFF")
            {
                Console.WriteLine("Would you like to buff a PLAYER or ALLY");
                choice = Console.ReadLine();
                if (choice == "PLAYER")
                {
                    Entity target = ChooseTarget(players.Cast<Entity>().ToList());
                    Buff(target);
                    DoTurn(players, allies, enemies);
                }
                else if (choice == "ALLY")
                {
                    Entity target = ChooseTarget(allies.Cast<Entity>().ToList());
                    Buff(target);
                    DoTurn(players, allies, enemies);
                }

            }
            else if (choice == "SUPERBUFF")
            {
                Console.WriteLine("Would you like to buff a PLAYER or ALLY");
                choice = Console.ReadLine();
                if (choice == "PLAYER")
                {
                    Entity target = ChooseTarget(players.Cast<Entity>().ToList());
                    SUPERBUFF(target);
                    DoTurn(players, allies, enemies);
                }
                else if (choice == "ALLY")
                {
                    Entity target = ChooseTarget(allies.Cast<Entity>().ToList());
                    SUPERBUFF(target);
                    DoTurn(players, allies, enemies);
                }

            }
            else if (choice == "HEAL")
            {
                Console.WriteLine("Would you like to heal a PLAYER or ALLY");
                choice = Console.ReadLine();
                if (choice == "PLAYER")
                {
                    Entity target = ChooseTarget(players.Cast<Entity>().ToList());
                    Heal(target);

                }
                else if (choice == "ALLY")
                {
                    Entity target = ChooseTarget(allies.Cast<Entity>().ToList());
                    Heal(target);

                }
                else if (choice == "SUPERHEAL")
                {
                    Console.WriteLine("Would you like to heal a PLAYER or ALLY");
                    choice = Console.ReadLine();
                    if (choice == "PLAYER")
                    {
                        Entity target = ChooseTarget(players.Cast<Entity>().ToList());
                        SUPERHeal(target);

                    }
                    else if (choice == "ALLY")
                    {
                        Entity target = ChooseTarget(allies.Cast<Entity>().ToList());
                        SUPERHeal(target);

                    }


                }
                else if (choice == "STATS")
                {
                    Console.WriteLine("Would you like to view a PLAYER, ALLY, or ENEMY's stats?");
                    choice = Console.ReadLine();
                    if (choice == "PLAYER")
                    {
                        Entity target = ChooseTarget(players.Cast<Entity>().ToList());
                        Console.WriteLine($"These are {target.name} stats.");
                        Console.WriteLine($"{target.currentHP}, {target.stats.strength}, {target.stats.defense}, {target.stats.speed}. These are {target.name}'s stats!");
                        DoTurn(players, allies, enemies);
                    }
                    else if (choice == "ALLY")
                    {
                        Entity target = ChooseTarget(allies.Cast<Entity>().ToList());
                        Console.WriteLine($"These are {target.name} stats.");
                        Console.WriteLine($"{target.currentHP}, {target.stats.strength}, {target.stats.defense}, {target.stats.speed}. These are {target.name}'s stats!");
                        DoTurn(players, allies, enemies);
                    }
                    else if (choice == "ENEMY")
                    {
                        Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                        Console.WriteLine($"These are {target.name} stats.");
                        Console.WriteLine($"{target.currentHP}, {target.stats.strength}, {target.stats.defense}, {target.stats.speed}. These are {target.name}'s stats!");
                        DoTurn(players, allies, enemies);
                    }
                    else
                    {
                        DoTurn(players, allies, enemies);
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
}
