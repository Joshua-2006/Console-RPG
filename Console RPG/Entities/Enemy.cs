using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Enemy : Entity
    {
       public static Enemy DragonFruit = new Enemy("Drago the Dragon Fruit", 500, 250, new Stats(100, 100, 100), 30, 500);
       public static Enemy ToothAche = new Enemy("Toothache", 60, 60, new Stats(10, 50, 70), 5, 50);
       public static Enemy KingCookie = new Enemy("King Cookie", 150, 150, new Stats(70, 70, 70), 50, 1000);
       public static Enemy CandySoldier = new Enemy("Candy Soldier", 100, 50, new Stats(50, 60, 50), 5, 50);
       public static Enemy CandyKnight = new Enemy("Candy Knight", 150, 100, new Stats(50, 80, 60), 5, 50);

        public int debuff;
        public int coins;
        public Enemy(string name, int hp, int mana, Stats stats, int debuff, int coins) : base(name, hp, mana, stats)
        {
            this.debuff = debuff;
            this.coins = coins;
        }
       
        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }
        public override void Attack(Entity target)
        {
            Console.WriteLine(this.name + " attacked " + target.name + "!");
        }

        public override void DoTurn(List<Player> players, List<Ally> allies, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target);
        }
    }
}
