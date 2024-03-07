namespace Console_RPG
{
    struct Stats
    {
        public int defense;
        public int speed;

        public int debuffResist;
        public int deathResist;
        public int dodgeChance;

        public int coinDropAmount;

        public Stats(int defense = 0, int speed = 0, int debuffResist = 15, int deathResist = 0, int dodgeChance = 0, int coinDropAmount = 0)
        {
            this.defense = defense;
            this.speed = speed;
            this.debuffResist = debuffResist;
            this.deathResist = deathResist;
            this.dodgeChance = dodgeChance;
            this.coinDropAmount = coinDropAmount;
        }
    }
}
