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
       public static Enemy Cavitee = new Enemy("Cavitee", 50, 100, new Stats(80, 20, 50), 5, 50);
       public static Enemy Hole = new Enemy("Hole", 10, 0, new Stats(100, 100, 100), 5, 50);

        public int debuff;
        public int coins;
        public Enemy(string name, int hp, int mana, Stats stats, int debuff, int coins) : base(name, hp, mana, stats)
        {
            this.debuff = debuff;
            this.coins = coins;
        }
        public void DeBuff(Entity target)
        {
            Stats stats = target.stats;
            int buffs = stats.strength -= target.currentHP - stats.strength;
            int buffy = stats.strength -= buffs;
            Console.WriteLine($"{target.name} was debuffed for {buffs} and lost that much attack!");
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }
        public override void Attack(Entity target)
        {
            Stats strats = this.stats;
            Stats stats = target.stats;
            int damage = strats.strength + stats.defense;
            int hp = target.currentHP -= damage;
            Console.WriteLine($"{this.name} attacked {target.name} for {damage} amount!");
        }

        public override void DoTurn(List<Player> players, List<Ally> allies, List<Enemy> enemies)
        {
            
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target);
            DeBuff(target);
        }
    }
}
