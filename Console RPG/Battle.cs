using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Console_RPG
{
    class Battle
    {
        public bool isResolved;
        public List<Enemy> enemies;

        public Battle(List<Enemy> enemies)
        {
            this.isResolved = false;
            this.enemies = enemies;
        }
        public void Resolve(List <Player> players, List<Ally> allies)
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
                }

                //Enemies
                foreach (var enemy in enemies)
                {
                    Console.WriteLine("It's " + enemy.name + "'s turn.");
                    enemy.DoTurn(players, allies, enemies);
                }
                // Allies
                foreach (var ally in allies)
                {
                    Console.WriteLine("It's " + ally.name + "'s turn.");
                    ally.DoTurn(players, allies, enemies);
                }
                // If all players die...
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("You failed... how dare you fail. THAT'S A SKILL ISSUE!!!");
                    break;
                }

                if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    Console.WriteLine("You actually survived... Congratulations.");
                    break;
                }
            }
        }
    }
}
