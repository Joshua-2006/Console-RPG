﻿namespace Console_RPG
{
    class Armor : Equipment
    {
        public int defenseMulti;

        public Armor(float durability, float weight, float rarity, int shopPrice, int maxAmount, string name, string description, int defenseMulti) : base(durability, weight, rarity, shopPrice, maxAmount, name, description)
        {
            //The defense multiplier the armor has.
            this.defenseMulti = defenseMulti;
        }

        public override void Use(Entity user, Entity target)
        {
            //Flips this value. Tells us if it's equipped or not equipped.
            this.isEquipped = !this.isEquipped;

            if(this.isEquipped)
            {
                //Increases target defense if they equip the item.
                target.stats.defense *= this.defenseMulti;
            }
            else
            {
                //Decrease target defense if they unequip the item.
                target.stats.defense /= this.defenseMulti;
            }
        }
    }
}