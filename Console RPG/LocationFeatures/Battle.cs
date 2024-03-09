using System;
using System.Collections.Generic;
using System.Threading;

namespace Console_RPG
{
    //b nbg vv bcbv n mc x (mario code)
    //i8 yhfguthgr (goku code)
    class Battle: LocationFeature
    {
        public List<Entity> party;
        public List<Entity> enemies;
        private List<Entity> turnOrder;

        public int round = 0;
        public int entityIndex = 1;

        private bool hasGottenItem = false;

        public Battle(List<string> enemies): base(false)
        {
            this.party = Battle.GetValid(Player.party);
            this.enemies = new List<Entity>();

            // Make Enemies

            foreach(string enemyType in enemies)
            {
                this.enemies.Add(CreateEnemy(enemyType));
                entityIndex++;
            }
        }

        // Battles

        public AI CreateEnemy(string EnemyType)
        {
            // Creation
            int maxHP = default;
            Stats stats = default;

            List<Move> moveset = new List<Move>();
            List<Item> backpack = new List<Item>();

            if (EnemyType == "Bandit")
            {
                stats = new Stats(speed: Entity.random.Next(2, 5), defense: Entity.random.Next(-1, 4), dodgeChance: Entity.random.Next(0, 15), coinDropAmount: Entity.random.Next(3, 7));
                maxHP = 40;

                moveset.Add(new Slash(missChance: 5, minDamage: 6, maxDamage: 16, critChance: 4));
            }
            else if (EnemyType == "Strong Bandit")
            {
                stats = new Stats(speed: Entity.random.Next(4, 7), defense: Entity.random.Next(5, 8), dodgeChance: Entity.random.Next(0, 5), deathResist: Entity.random.Next(10, 25), coinDropAmount: Entity.random.Next(5, 11));
                maxHP = 60;

                Slash slash = new Slash(minDamage: 14, maxDamage: 20, critChance: 15, missChance: 15);
                slash.name = "Super Slash";

                moveset.Add(slash);
            }
            else if (EnemyType == "Gambler Bandit")
            {
                stats = new Stats(speed: Entity.random.Next(-5, 15), defense: 0, dodgeChance: Entity.random.Next(40, 70), deathResist: Entity.random.Next(0, 25), coinDropAmount: Entity.random.Next(11, 17));
                maxHP = 10;

                Gambler gambler = new Gambler(minDamage: 12, maxDamage: 16, critChance: 90, missChance: 50);
                moveset.Add(gambler);
            }
            else if (EnemyType == "Sharko")
            {
                stats = new Stats(speed: Entity.random.Next(-3, 8), defense: 5, dodgeChance: 0, deathResist: 0, coinDropAmount: Entity.random.Next(6, 12));
                maxHP = 50;

                Slash slash = new Slash(minDamage: 12, maxDamage: 15, critChance: 10, missChance: 0);
                slash.name = "Swing";

                moveset.Add(slash);

                Slash kick = new Slash(minDamage: 25, maxDamage: 30, critChance: 0, missChance: 10);
                slash.name = "Kick";

                moveset.Add(kick);
            }
            else if (EnemyType == "Duke Erisia")
            {
                stats = new Stats(speed: Entity.random.Next(8, 14), defense: 12, dodgeChance: Entity.random.Next(1, 4), deathResist: Entity.random.Next(60, 80), coinDropAmount: Entity.random.Next(1000, 10000));
                maxHP = 500;

                Slash strongLeft = new Slash(minDamage: 18, maxDamage: 46, critChance: 35, missChance: 0);
                strongLeft.name = "Strong Left";

                moveset.Add(strongLeft);

                Bounce cages = new Bounce(minDamage: 22, maxDamage: 42, critChance: 20, missChance: 0);
                cages.name = "Binding Tempest";

                moveset.Add(cages);

                moveset.Add(new Vent());
                moveset.Add(new Servants());
            }
            else if (EnemyType == "Duke's Servant")
            {
                stats = new Stats(speed: Entity.random.Next(-12, -4), defense: 0, dodgeChance: 0, deathResist: 1, coinDropAmount: Entity.random.Next(10, 100));
                maxHP = 10;

                Slash slash = new Slash(minDamage: 3, maxDamage: 8, critChance: 30, missChance: 5);
                slash.name = "Swing";

                moveset.Add(slash);
            }
            else
            {
                moveset.Add(new Slash());
            }

            return new AI(name: $"{EnemyType} {entityIndex}", maxHP, stats, moveset, backpack);
        }

        // Battle

        public override void Resolve()
        {
            StartBattle();
        }

        public void StartBattle()
        {
            Console.Clear();

            Program.PrintWithColor("BATTLE START!", ConsoleColor.DarkYellow);
            Thread.Sleep(2000);

            StartRound();
        }

        void EndBattle(bool PartyAlive)
        {
            Thread.Sleep(1000);

            if (PartyAlive == false)
            {
                lostGame = true;

                Console.Clear();
                Program.PrintWithColor("\nSent to the Depths..", ConsoleColor.DarkRed);
            }
            else
            {
                Program.PrintWithColor("\nBattle won!", ConsoleColor.Cyan);

                int coinsGained = 0;

                foreach (Entity entity in enemies)
                    coinsGained += entity.stats.coinDropAmount;

                Program.PrintWithColor($"{coinsGained}¢ acquired!", ConsoleColor.Cyan);
                Player.coins += coinsGained;

                // Revive from Death's Door

                foreach (Entity entity in party)
                {
                    if (entity.onDeathsDoor == true)
                    {
                        entity.onDeathsDoor = false;
                        entity.health = 1;
                    }
                }
            }

            Thread.Sleep(3000);
            Console.Clear();
        }

        // Round

        void StartRound()
        {
            round++;

            turnOrder = GetAllEntities();
            turnOrder.Sort(TurnOrderCompare);

            foreach (Entity entity in turnOrder)
            {
                if (entity.isDead == true)
                    continue;

                PrintRoundInfo();

                Thread.Sleep(1000);
                DoTurn(entity);

                if (enemies.TrueForAll(x => x.isDead == true))
                {
                    EndBattle(true);
                    return;
                }
                else if (party.TrueForAll(x => x.isDead == true))
                {
                    EndBattle(false);
                    return;
                }

                Console.Clear();
            }

            Thread.Sleep(1000);
            StartRound();
        }

        // Round Helpers

        void PrintRoundInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Round " + round);

            // Print Party

            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (Entity entity in party)
            {
                Console.WriteLine("\n" + entity);
            }

            // Versus

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nVS");

            // Print Enemies

            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (Entity entity in enemies)
            {
                Console.WriteLine("\n" + entity);
            }

            // Separator

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-------------");
        }

        int TurnOrderCompare(Entity a, Entity b)
        {
            if (a.stats.speed > b.stats.speed)
            {
                return -1; // Lower index -> faster.
            } else if (a.stats.speed < b.stats.speed)
            {
                return 1; // Higher index -> slower.
            } else
            {
                return 0; // I dont know what happens
            }
        }

        // Turn

        void DoTurn(Entity entity)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{entity.name}'s turn!\n");
            Console.ForegroundColor = ConsoleColor.White;

            string action;
            int stupidTimes = 0;

            while (true)
            {
                action = entity.ChooseAction(new List<string>() { "Attack", "Item" });

                if (action == "Item" && entity.backpack.Count == 0)
                {
                    stupidTimes++;

                    if (stupidTimes == 8)
                    {
                        if (hasGottenItem == true)
                        {
                            Program.PrintWithColor("lol u dont get another one\n", ConsoleColor.DarkCyan);
                            Thread.Sleep(1500);
                            break;
                        }

                        Program.PrintWithColor("ok fine u so stupid u get item\n", ConsoleColor.DarkCyan);
                        entity.backpack.Add(new HealthPotion("stupid potion", healAmount: 2));

                        hasGottenItem = true;
                        Thread.Sleep(1500);

                        break;
                    }

                    Program.PrintWithColor("haha u stupid u got no item\n", ConsoleColor.DarkCyan);
                    Thread.Sleep(1500);

                    continue;
                }

                break;
            }
            
            if (action == "Attack")
            {
                Move move = entity.ChooseMove(entity.moveset);
                List<Entity> validChoices = GetValid(GetTeam(entity, otherTeam: true));

                if (move.isMultiAttack == true)
                {
                    foreach (Entity target in validChoices)
                    {
                        entity.Attack(target, move, this);

                        Thread.Sleep(2000);
                        Console.ResetColor();
                    }
                } else
                {
                    Entity target = entity.ChooseTarget(move.name, validChoices);
                    Console.ForegroundColor = ConsoleColor.White;

                    entity.Attack(target, move, this);
                }
            } else if (action == "Item")
            {
                Item item = entity.ChooseItem(entity.backpack);
                Entity target = entity.ChooseTarget(item.name, GetValid(GetTeam(entity, otherTeam: false)));

                Console.ForegroundColor = ConsoleColor.White;
                entity.UseItem(item, target);
            }

            Thread.Sleep(2000);
            Console.ResetColor();
        }

        // Helpers

        public List<Entity> GetTeam(Entity entity, bool otherTeam = false)
        {
            if (otherTeam == false)
            {
                if (party.Find(x => x.name == entity.name) != null)
                    return party;
                else
                    return enemies;
            } else
            {
                if (party.Find(x => x.name == entity.name) != null)
                    return enemies;
                else
                    return party;
            }
        }

        public static List<Entity> GetValid(List<Entity> group)
        {
            List<Entity> entities = new List<Entity>();

            foreach (Entity entity in group)
            {
                if (entity.isDead == false)
                    entities.Add(entity);
            }

            return entities;
        }

        public List<Entity> GetAllEntities()
        {
            List<Entity> entities = new List<Entity>();

            foreach (Entity entity in party)
            {
                entities.Add(entity);
            }

            foreach (Entity entity in enemies)
            {
                entities.Add(entity);
            }

            return entities;
        }
    }
}





















//clueless