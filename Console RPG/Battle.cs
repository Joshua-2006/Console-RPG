﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;
namespace Console_RPG
{
    class Battle : LocationEvent
    {
        
        public List<Enemy> enemies;

        public Battle(List<Enemy> enemies) : base(false)
        {
            this.enemies = enemies;
        }
        public override void Resolve(List<Player> players, List<Ally> allies)
        {
            while (true)
            {
                //pLAYERS
                foreach (var player in players)
                {
                    if(player.currentHP > 0)
                    {
                    Console.WriteLine("It's " + player.name + "'s turn.");
                   player.DoTurn(players, allies, enemies);
                    }
                    if (player.currentHP < 0) 
                    {
                        Console.WriteLine($"{player.name} has died.");
                    }
                }

                //Enemies
                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    {
                        Console.WriteLine("It's " + enemy.name + "'s turn.");
                       enemy.DoTurn(players, allies, enemies);
                    }
                    if (enemy.currentHP < 0)
                    {
                        Console.WriteLine($"{enemy.name} has died.");
                    }
                }
                // Allies
                foreach (var ally in allies)
                {
                    if (ally.currentHP > 0)
                    {
                    Console.WriteLine("It's " + ally.name + "'s turn.");
                    ally.DoTurn(players, allies, enemies);
                    }
                    if (ally.currentHP < 0)
                    {
                        Console.WriteLine($"{ally.name} has died.");
                    }
                }
                // If all players die...
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("You failed... how dare you fail. THAT'S A SKILL ISSUE!!!");
                    break;
                }

                if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    Console.WriteLine($"You actually survived... Congratulations.");
                    break;
                }
            }
        }
    }
}
