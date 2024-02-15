using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Ally : Entity
    {
        public int DoT;
        public int Item;
        public Ally(string name, int hp, int mana, Stats stats, int DoT, int Item) : base(name, hp, mana, stats)
        {
            this.DoT = DoT;
            this.Item = Item;
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
