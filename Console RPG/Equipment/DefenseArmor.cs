using System;

namespace Console_RPG
{
    class DefenseArmor : Equipment
    {
        public int defenseAmount;

        public DefenseArmor(string name, string description = "", int shopPrice = default, int defenseAmount = 3) : base(name, description, shopPrice, "Armor")
        {
            this.defenseAmount = defenseAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            if (isEquipped == false)
            {
                target.stats.defense += defenseAmount;
                Program.PrintWithColor($"Equipped {name}: increased {target.name} defense by {defenseAmount}.", ConsoleColor.DarkCyan);
            }
            else
            {
                target.stats.defense -= defenseAmount;
                Program.PrintWithColor($"Unequipped {name}, reducing {target.name} defense by {defenseAmount}.", ConsoleColor.DarkMagenta);
            }

            isEquipped = !isEquipped;
        }
    }
}
