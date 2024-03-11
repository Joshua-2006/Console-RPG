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
       public static Enemy Pokemon = new Enemy("Turdwig", 100, 100, new Stats(100, 100, 100), 10, 1000);
        public static Enemy Pokemon1 = new Enemy("Litturn", 100, 100, new Stats(100, 100, 100), 10, 1000);
        public static Enemy Pokemon2 = new Enemy("Mudkarp", 100, 100, new Stats(100, 100, 100), 10, 1000);
        public static Enemy PhoenixWright = new Enemy("Phoenix Wright", 1000, 1000, new Stats(1000, 1000, 1000), 100, 1000);
        public static Enemy Skylander = new Enemy("Spyro", 5000, 5000, new Stats(5000, 5000, 5000), 150, 5000);
        public static Enemy Skylander1 = new Enemy("Stealth Elf", 5000, 5000, new Stats(5000, 5000, 5000), 150, 5000);
        public static Enemy Skylander2 = new Enemy("Eruptor", 5000, 5000, new Stats(5000, 5000, 5000), 150, 5000);
        public static Enemy Jax = new Enemy("Jax", 10000, 10000, new Stats(7500, 7500, 7500), 100, 7500);
        public static Enemy Ethan = new Enemy("Ethan", 10000, 10000, new Stats(7500, 7500, 7500), 100, 7500);
        public static Enemy Andrew = new Enemy("Andrew", 10000, 10000, new Stats(7500, 7500, 7500), 100, 7500);
        public static Enemy Toby = new Enemy("Toby", 10000, 10000, new Stats(7500, 7500, 7500), 100, 7500);

        public int debuff;
        public int coins;
        public Enemy(string name, int hp, int mana, Stats stats, int debuff, int coins) : base(name, hp, mana, stats)
        {
            this.debuff = debuff;
            this.coins = coins;
        }
        public void DeBuff(Entity target)
        {
            
            int buffs = target.stats.strength -= this.debuff * this.debuff;
            Console.WriteLine($"{target.name} was debuffed for {buffs} and lost that much attack!");
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }
        public override void Attack(Entity target)
        {
            int damage = this.stats.strength - target.stats.defense;
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
