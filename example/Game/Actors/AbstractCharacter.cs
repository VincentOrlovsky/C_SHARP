using Game.Strategies;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Game.Actors
{
    public abstract class AbstractCharacter : AbstractActor, ICharacter, IMovable
    {
        private List<Command> effects;

        private double speed;
        private ISpeedStrategy speedStrategy;

        private int health;

        public AbstractCharacter()
        {
            speedStrategy = new NormalSpeedStrategy();
            effects = new List<Command>();
        }

        public void ChangeHealth(int delta)
        {
            health += delta;
            if(health <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            
        }

        public int GetHealth()
        {
            return health;
        }

        public void SetHealth(int health)
        {
            this.health = health;
        }

        public void AddEffect(Command effect)
        {
            effects.Add(effect);
        }

        public void RemoveEffect(Command effect)
        {
            if (effects.Contains(effect))
            {
                effects.Remove(effect);
            }
        }
        public override void Update()  // override
        {   
            
            foreach (Command i in effects)
            {
                if (i == null) continue;
                else i.Execute();
            }
        }

        public double GetSpeed(double speed)
        {
            return speedStrategy.GetSpeed(speed);
        }

        public void SetSpeedStrategy(ISpeedStrategy speedStrategy)
        {
            this.speedStrategy = speedStrategy;
        }
    }
}
