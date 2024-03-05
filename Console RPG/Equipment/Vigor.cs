using System;

namespace Console_RPG
{
    class Vigor : Equipment
    {
        public int resistAmount;

        public Vigor(string name, string description, int shopPrice, int resistAmount = 10): base(name, description, shopPrice)
        {
            this.resistAmount = resistAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            target.stats.deathResist = Math.Clamp(target.stats.deathResist + resistAmount, 0, 95);
            Console.WriteLine("Increased " + target.name + " death resist to " + target.stats.deathResist + "%.");
        }
    }
}
