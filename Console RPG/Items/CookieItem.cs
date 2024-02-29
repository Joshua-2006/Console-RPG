using System;

namespace Console_RPG
{
    class CookieItem : Item
    {
       

        public int damage;
        public int amount;

        public CookieItem(int shopPrice, int maxAmount, string name, string description, int damage, int amount) : base (shopPrice, maxAmount, name, description)
        {
            this.damage = damage;
            this.amount = amount;
        }

        public override void Use(Entity user, Entity target)
        {
            if (amount == 0)
                return;
            target.currentHP -= this.damage;
            --amount;
            Console.WriteLine(target.name + " took " + this.damage + " amount of damage and is now at " + target.currentHP + " amount of HP!");
        }
    }
}
