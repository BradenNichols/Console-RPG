using Console_RPG.BaseClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Shop : LocationFeature
    {
        public string shopKeeperName;
        public List<Item> items;

        public Shop(bool isResolved) : base(isResolved)
        {
        }

        public override void Resolve()
        {
            Console.WriteLine($"Welcome to {shopKeeperName}'s shop!");
        }
    }
}
