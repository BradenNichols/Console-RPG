using System;

namespace Console_RPG
{
    class Hivelords : Equipment
    {
        public float dmgMultiplier;

        public Hivelords(string name, string description = "", int shopPrice = default, float dmgMultiplier = 0.4f) : base(name, description, shopPrice, "Weapon")
        {
            this.dmgMultiplier = dmgMultiplier;
        }

        public override void Use(Entity user, Entity target)
        {
            if (isEquipped == false)
            {
                target.stats.dmgModifier += dmgMultiplier;
                Program.PrintWithColor($"Equipped {name}: increased {target.name} dmg by {dmgMultiplier}x.", ConsoleColor.DarkCyan);
            }
            else
            {
                target.stats.dmgModifier -= dmgMultiplier;
                Program.PrintWithColor($"Unequipped {name}, reducing {target.name} dmg by {dmgMultiplier}x.", ConsoleColor.DarkMagenta);
            }

            isEquipped = !isEquipped;
        }
    }
}
