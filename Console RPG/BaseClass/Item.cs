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

        public Item(string name, string description, int shopPrice = 0)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.sellPrice = shopPrice / 2;
        }

        public abstract void Use(Entity user, Entity target);
    }
}
