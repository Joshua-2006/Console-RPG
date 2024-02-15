using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public int shopPrice;
        public int maxAmount;

        public string name;
        public string description;

        public Item(int shopPrice, int maxAmount, string name, string description)
        {
            this.shopPrice = shopPrice;
            this.maxAmount = maxAmount;
            this.name = name;
            this.description = description;
        }

        public abstract void Use(Entity user, Entity target);
    }
}
