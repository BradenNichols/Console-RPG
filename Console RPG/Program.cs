using System;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Player derek = new Player("Derek", maxhp: 30, new Stats(defense: 0, speed: -4, debuffResist: 20, deathResist: 65, dodgeChance: 50));
            Player jaden = new Player("Jaden", maxhp: 150, new Stats(defense: 6, speed: -10, debuffResist: 40, deathResist: 80, dodgeChance: 6));

            AI jackson = new AI("Jackson", maxhp: 50, new Stats(defense: 1, speed: 4, debuffResist: 15, deathResist: 25, dodgeChance: 25));
            AI button = new AI("the button", maxhp: 1, new Stats(defense: 100, speed: 2, debuffResist: 0, deathResist: 0, dodgeChance: 95));

            HealthPotion potion1 = new HealthPotion("Potion1", "one", 10, 5);
            HealthPotion potiondead = new HealthPotion("Potiondead", "two", 20, 5, 2, -20);

            derek.UseItem(potion1, jackson);
            button.UseItem(potion1, jackson);

            Vigor vigor1 = new Vigor("invigorating", "mhm", 50, 30, 4, 15);
            jaden.UseItem(vigor1, derek);

            //bool[] ranks = { true };
        }
    }
}
