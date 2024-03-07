using System;

namespace Console_RPG
{
    class HealthPotion : Item
    {
        public int healAmount;

        public HealthPotion(string name, string description = "", int healAmount = 10, int shopPrice = 5) : base(name, description, shopPrice)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            target.Heal(healAmount);
        }
    }
}
