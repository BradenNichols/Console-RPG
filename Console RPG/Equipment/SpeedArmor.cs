using System;

namespace Console_RPG
{
    class SpeedArmor : Equipment
    {
        public int speedAmount;

        public SpeedArmor(string name, string description = "", int shopPrice = default, int speedAmount = 3): base(name, description, shopPrice, "Armor")
        {
            this.speedAmount = speedAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            if (isEquipped == false)
            {
                target.stats.speed += speedAmount;
                Program.PrintWithColor($"Equipped {name}: increased {target.name} speed by {speedAmount}%.", ConsoleColor.DarkCyan);
            } else
            {
                target.stats.speed -= speedAmount;
                Program.PrintWithColor($"Unequipped {name}, reducing {target.name} speed by {speedAmount}%.", ConsoleColor.DarkMagenta);
            }

            isEquipped = !isEquipped;
        }
    }
}
