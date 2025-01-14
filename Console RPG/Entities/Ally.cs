﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace Console_RPG
{
    class Ally : Entity
    {
       public static Ally Cavity = new Ally("Cavity", 50, 50, new Stats(200, 40, 80), 10, 50);
        public static Ally Ytivac = new Ally("Cavity", 50, 50, new Stats(200, 40, 80), 10, 50);
        public static Ally Derek = new Ally("Derek", 100000, 100000, new Stats(1000000, 1000000, 1000000), 1000000, 1000000);
        public int DoT;
        public int Item;
        public Ally(string name, int hp, int mana, Stats stats, int DoT, int Item) : base(name, hp, mana, stats)
        {
            this.DoT = DoT;
            this.Item = Item;
        }
        public override void DoTurn(List<Player> players, List<Ally> allies, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
            Attack(target);
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
    }
}
