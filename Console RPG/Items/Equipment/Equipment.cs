using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public float durability;
        public float weight;
        public float rarity;
        public bool isEquipped;

        protected Equipment(float durability, float weight, float rarity, int shopPrice, int maxAmount, string name, string description) : base (shopPrice, maxAmount, name, description)
        {
            this.durability = durability;
            this.weight = weight;
            this.rarity = rarity;
            this.isEquipped = false;
        }
    }
}
