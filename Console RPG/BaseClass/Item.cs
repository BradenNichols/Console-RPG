using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public string name;
        public string description;

        public int shopPrice;
        public int sellPrice;
        public int weight;

        public Item(string name, string description, int shopPrice, int sellPrice, int weight = 1)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.sellPrice = sellPrice;
            this.weight = weight;
        }

        public abstract void Use(Entity user, Entity target);
    }
}
