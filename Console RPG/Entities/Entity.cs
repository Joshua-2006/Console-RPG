using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    // Classes are useful for storing complex objects.
    abstract class Entity
    {
        public string name;

        public int currentHP, maxHP;
        public int currenMana, maxMana;
        // This is called compostition. Composition is awesome!
        public Stats stats;
       
        public Entity(string name, int hp, int mana, Stats stats)
        {
            this.name = name;
            this.currentHP = hp;
            this.maxHP = hp;
            this.currenMana = mana;
            this.maxMana = mana;
            this.stats = stats;
          
        }

        public abstract void DoTurn(List<Player> players, List<Ally> allies, List<Enemy> enemies);
        public abstract Entity ChooseTarget(List<Entity> targets);
        public abstract void Attack(Entity target);

        public void UseItem(Item item, Entity user)
        {
            item.Use(this, user);
        }
    }
}
