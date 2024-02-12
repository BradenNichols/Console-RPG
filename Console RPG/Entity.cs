using System;
using System.Collections.Generic;
using System.Text;
using Console_RPG.Moveset;

namespace Console_RPG
{
    abstract class Entity
    {
        public string name;
        public int health, maxHealth;

        // Composition
        public Stats stats;

        public Entity(string name, int maxhp = 100, Stats stats = new Stats())
        {
            this.name = name;
            this.health = maxhp;
            this.maxHealth = maxhp;

            this.stats = stats;
        }

        public abstract Entity ChooseTarget(List<Entity> choices);

        public void Attack(Entity target, Move move)
        {
            move.Attack(this, target);
        }
    }

    // Class Ally : Entity?
}
