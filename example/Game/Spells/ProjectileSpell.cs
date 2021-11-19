using Game.Actors;
using Game.Strategies;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Spells
{
    public class ProjectileSpell : AbstractActor, ISpell, IMovable
    {
        private int cost;
        private double speed;
        private List<Command> effects;

        private ISpeedStrategy speedStrategy;
        private IWizard wizard;
        private bool isFacingRight;
        private Animation ani;

        private bool itsFlipped;

        public ProjectileSpell(IWizard wizard, int cost, Animation ani)   // 
        {
            this.cost = cost;
            speedStrategy = new NormalSpeedStrategy();
            this.wizard = wizard;
            isFacingRight = wizard.IsFacingRight();
            this.ani = ani;
            SetAnimation(ani);
            GetAnimation().Start();
            itsFlipped = false;

        }

        public ISpell AddEffect(Command effect)
        {
            effects.Add(effect);
            return this;
        }

        public void AddEffects(IEnumerable<Command> effects)
        {
            this.effects = effects.ToList();
        }

        public void Cast()
        {
            if (wizard.GetMana() < cost) return;
            wizard.GetWorld().AddActor(this);
            this.SetPosition(wizard.GetX(), wizard.GetY());
            wizard.ChangeMana(-cost);

        }

        public int GetCost()
        {
            return cost;
        }

        public double GetSpeed(double speed)
        {
            return GetSpeed(speed);
        }

        public void SetSpeedStrategy(ISpeedStrategy speedStrategy)
        {
            this.speedStrategy = speedStrategy;
        }

        public IActor Interction(List<IActor> list)
        {
            foreach (IActor actor in list)
            {
                if (actor == this) continue;
                if (actor == wizard) continue;
                if (IntersectsWithActor(actor))
                {
                    return actor;
                }
            }

            return null;
        }

        public override void Update()
        {
            base.Update();

            if (isFacingRight)
            {

                SetPosition(GetX() + 3, GetY());
                if (GetWorld().IntersectWithWall(this))
                {
                    RemoveFromWorld();
                }
            }
            else
            {
                if (!itsFlipped)
                {
                    GetAnimation().FlipAnimation();
                    itsFlipped = true;
                }

                SetPosition(GetX() - 3, GetY());
                if (GetWorld().IntersectWithWall(this))
                {
                    RemoveFromWorld();
                }
            }

            IActor actor = Interction(GetWorld().GetActors());
            if (actor is ICharacter)
            {
                AbstractCharacter character = (AbstractCharacter)GetWorld().GetActors().Find(a => a == actor);
                foreach(Command e in effects)
                {
                    IDangerousSpell spell = (IDangerousSpell)e;
                    spell.SetTarget(character);
                    character.AddEffect(e);
                }

                /*ICharacter target = (Enemy)GetWorld().GetActors().First(a => a.IntersectsWithActor(this) && a is Enemy);
                effects.ForEach(e => target.AddEffect(e));*/

            }


        }
    }
}
