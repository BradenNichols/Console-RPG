using System;

namespace Console_RPG
{
    class HealthPotion : Item
    {
        public int healAmount;

        public HealthPotion(string name, string description = "", int shopPrice = 0, int sellPrice = 0, int weight = 1, int healAmount = 10): base(name, description, shopPrice, sellPrice, weight)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            target.Heal(healAmount);
        }
    }
}
