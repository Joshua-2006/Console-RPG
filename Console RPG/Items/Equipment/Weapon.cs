namespace Console_RPG
{
    class Weapon : Equipment
    {
        public int damageMulti;

        public Weapon(float durability, float weight, float rarity, int shopPrice, int maxAmount, string name, string description, int damageMulti) : base(durability, weight, rarity, shopPrice, maxAmount, name, description)
        {
            //The defense multiplier the armor has.
            this.damageMulti = damageMulti;
        }

        public override void Use(Entity user, Entity target)
        {
            //Flips this value. Tells us if it's equipped or not equipped.
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                //Increases target attack if they equip the item.
                target.stats.strength *= this.damageMulti;
            }
            else
            {
                //Decrease target attack if they unequip the item.
                target.stats.strength /= this.damageMulti;
            }
        }
    }
}
