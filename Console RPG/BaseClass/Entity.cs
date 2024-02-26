using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Entity
    {
        public string name;
        public int health, maxHealth;

        // Composition
        public Stats stats;
        public List<Move> moveset;

        public Entity(string name, int maxhp = 100, Stats stats = new Stats(), List<Move> moveset = null)
        {
            this.name = name;
            this.health = maxhp;
            this.maxHealth = maxhp;

            this.stats = stats;
            this.moveset = moveset ?? new List<Move>();
        }

        //public abstract (Move, Entity) ChooseMove(List<Move> moves, List<Entity> entities);
        public abstract Move ChooseMove(List<Move> choices);
        public abstract Entity ChooseTarget(Move move, List<Entity> choices);
        
        public void Attack(Entity target, Move move)
        {
            move.Attack(this, target);
        }

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }

        public void Damage(int amount)
        {
            health = Math.Clamp(health - amount, 0, maxHealth);
        }
    }

    // Class Ally : Entity?
}
