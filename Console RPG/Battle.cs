﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{
    //b nbg vv bcbv n mc x (mario code)
    class Battle
    {
        public List<Entity> party;
        public List<Entity> enemies;
        private List<Entity> turnOrder;

        public int round = 0;

        public Battle(List<Entity> party, List<Entity> enemies)
        {
            this.party = party;
            this.enemies = enemies;
        }

        // Round

        public void Start()
        {
            round++;

            turnOrder = GetAllEntities();
            turnOrder.Sort(TurnOrderCompare);

            foreach (Entity entity in turnOrder)
            {
                if (enemies.TrueForAll(entity => entity.health <= 0))
                {
                    EndBattle(true);
                    return;
                } else if (party.TrueForAll(entity => entity.health <= 0))
                {
                    EndBattle(false);
                    return;
                }

                if (entity.isDead == true)
                    continue;

                PrintRoundInfo();

                Thread.Sleep(1000);
                DoTurn(entity);

                Console.Clear();
            }

            Thread.Sleep(1000);
            Start();
        }

        void EndBattle(bool PartyAlive)
        {
            if (PartyAlive == false)
            {
                Console.WriteLine("L");
            } else
            {
                Console.WriteLine("W");
            }
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

            Move move = entity.ChooseMove(entity.moveset);
            Entity target = entity.ChooseTarget(move, GetOtherTeam(entity));

            Console.ForegroundColor = ConsoleColor.White;
            entity.Attack(target, move);

            Thread.Sleep(2000);
        }

        // Helpers

        public List<Entity> GetOtherTeam(Entity entity)
        {
            if (party.Find(x => x.name == entity.name) != null)
            {
                return enemies;
            } else
            {
                return party;
            }
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

        public List<Entity> GetTargets(Entity user, Move move)
        {
            List<Entity> targets = new List<Entity>();
            // return all the targets that are valid within the move.ranks
            return targets; 
        }
    }
}
