using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Player : Entity
    {
        public int buff;
        public int heal;
        public Player(string name, int hp, int mana, Stats stats, int buff, int heal) : base(name, hp, mana, stats)
        {
            this.buff = buff;
            this.heal = heal;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            // You guys figure this one out.
            return targets[0];
            

        }
        public override void Attack(Entity target)
        {
            Console.WriteLine(this.name + " attacked " + target.name + "!");
            
        }
    }
}
