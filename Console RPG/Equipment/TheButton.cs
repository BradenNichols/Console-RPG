using System;

namespace Console_RPG
{
    class TheButton : Equipment
    {
        private Move buttonMove;

        public TheButton(string name, string description = "", int shopPrice = default) : base(name, description, shopPrice, "Weapon")
        {
            buttonMove = new Button();
        }

        public override void Use(Entity user, Entity target)
        {
            if (isEquipped == false)
            {
                Program.PrintWithColor($"Equipped {name}..", ConsoleColor.DarkCyan);
                target.moveset.Add(buttonMove);
            }
            else
            {
                Program.PrintWithColor($"Unequipped {name}..", ConsoleColor.DarkMagenta);
                target.moveset.Remove(buttonMove);
            }

            isEquipped = !isEquipped;
        }
    }
}
