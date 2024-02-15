using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Enemy : Entity
    {
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
    }
}
