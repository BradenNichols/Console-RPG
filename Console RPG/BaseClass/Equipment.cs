using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public bool isEquipped;
        public string equipmentType;

        protected Equipment(string name, string description, int shopPrice = 0, string equipmentType = null) : base(name, description, shopPrice)
        {
            isEquipped = false;
            this.equipmentType = equipmentType;
        }

        public override string ToString()
        {
            return $"{name}: {description} ({equipmentType}) | Price: {shopPrice}¢";
        }
    }
}
