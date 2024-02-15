using System;

namespace Console_RPG
{
    class VitaminItem : Item
    {
        public int healAmount;
        public int vitaminAmount;
        public VitaminItem(int shopPrice, int maxAmount, string name, string description, int healAmount, int vitaminAmount) : base(shopPrice, maxAmount, name, description)
        {
            this.healAmount = healAmount;
            this.vitaminAmount = vitaminAmount;
        }
        public override void Use(Entity user, Entity Target)
        {
            user.currentHP += this.healAmount;
            this.vitaminAmount -= 1;
            Console.WriteLine(user.name + " used a vitamin and restored " + this.healAmount + " to their HP! They now have " + user.currentHP + " amount of HP!");
        }
    }
}
