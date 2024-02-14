using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Battle
    {
        public List<Entity> party;
        public List<Entity> enemies;

        public int round = 0;

        public Battle(List<Entity> party, List<Entity> enemies)
        {
            this.party = party;
            this.enemies = enemies;
        }

        // Round

        public void BeginRound()
        {
            round++;
        }

        // Helpers

        public List<Entity> GetTargets(Entity user, Move move)
        {
            List<Entity> targets = new List<Entity>();
            // return all the targets that are valid within the move.ranks
            return targets; 
        }
    }
}
