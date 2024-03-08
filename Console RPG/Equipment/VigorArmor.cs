using System;

namespace Console_RPG
{
    class VigorArmor : Equipment
    {
        public int resistAmount;
        private int appliedAmount;

        public VigorArmor(string name, string description = "", int shopPrice = default, int resistAmount = 10): base(name, description, shopPrice, "Armor")
        {
            this.resistAmount = resistAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            if (isEquipped == false)
            {
                int currentResist = target.stats.deathResist;
                int newResist = Math.Clamp(currentResist + resistAmount, 0, 95);

                appliedAmount = newResist - currentResist;
                target.stats.deathResist = newResist;

                Program.PrintWithColor($"Equipped {name}: increased {target.name} death's door resist by {resistAmount}%.", ConsoleColor.DarkCyan);
            } else
            {
                target.stats.deathResist -= Math.Clamp(target.stats.deathResist - appliedAmount, 0, 95);
                Program.PrintWithColor($"Unequipped {name}, reducing {target.name} death's door resist by {resistAmount}%.", ConsoleColor.DarkMagenta);
            }

            isEquipped = !isEquipped;
        }
    }
}
