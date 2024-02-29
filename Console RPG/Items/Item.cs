using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public static CookieItem Cookie = new CookieItem(500, 2, "Cookie", "These cookies are razor sharp. Sharp enough to kill anything...", 500, 100);
        public static CookieItem BurntCookie = new CookieItem(1000, 1, "Burnt Cookie", "This is a burnt cookie. DON'T BUY IT! I'M SERIOUS!", 1000, 1);
        public static SugarItem ChocolateBar = new SugarItem(50, 30, "Chocolate Bar", "This Bar isn't made of Candy people... surely not?", 50, 1);
        public static SugarItem LegendaryCookie = new SugarItem(100, 10, "Legendary Cookie", "These Cookies are very tasty! There is nothing wrong with them! AT ALL...", 100, 2);
        public static VitaminItem VitaminC = new VitaminItem(shopPrice: 50, maxAmount: 30, "Vitamin C", "This is some Vitamin C! It'll boost your Immune System... totally...", healAmount: 50, vitaminAmount: 1);
        public static VitaminItem Vitalizer = new VitaminItem(100, 10, "Vitalizer", "It supposedly should give you extra vitality... why do people like it so much?", 100, 2);

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
