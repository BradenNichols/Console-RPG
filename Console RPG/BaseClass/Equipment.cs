using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public bool isEquipped;

        protected Equipment(string name, string description, int shopPrice = 0) : base(name, description, shopPrice)
        {
            isEquipped = false;
        }
    }
}
