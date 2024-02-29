using System;

namespace Console_RPG
{
    class SugarItem : Item
    {
     

        public int manaRestoreAmount;
        public int sugarAmount;
        public SugarItem(int shopPrice, int maxAmount, string name, string description, int manaRestoreAmount, int sugarAmount) : base(shopPrice, maxAmount, name, description)
        {
            this.manaRestoreAmount = manaRestoreAmount;
            this.sugarAmount = sugarAmount;
        }
        public override void Use(Entity user, Entity Target)
        {
            user.currenMana += this.manaRestoreAmount;
            this.sugarAmount -= 1;
            Console.WriteLine(user.name + " used some sugar and restored " + this.manaRestoreAmount + " to their mana amount! They now have " + user.currenMana + " amount of Mana!");
        }
    }
}
