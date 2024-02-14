using System;

namespace Console_RPG
{
    class Vigor : Item
    {
        public int resistAmount;

        public Vigor(string name, string description, int shopPrice, int sellPrice, int weight = 1, int resistAmount = 10): base(name, description, shopPrice, sellPrice, weight)
        {
            this.resistAmount = resistAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            target.stats.deathResist = Math.Clamp(target.stats.deathResist + resistAmount, 0, 95);
            Console.WriteLine("increased " + target.name + " death resist to " + target.stats.deathResist + "%");
        }
    }
}
