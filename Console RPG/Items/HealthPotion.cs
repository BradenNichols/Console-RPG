using System;

namespace Console_RPG
{
    class HealthPotion : Item
    {
        public int healAmount;

        public HealthPotion(string name, string description, int shopPrice, int sellPrice, int weight = 1, int healAmount = 10): base(name, description, shopPrice, sellPrice, weight)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            target.health = Math.Clamp(target.health - healAmount, 0, target.maxHealth);
            Console.WriteLine("Healed " + target.name + " to " + target.health + " HP.");
        }
    }
}
