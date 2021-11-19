using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    public class ManaRock : AbstractActor
    {
        private Animation rock;

        public ManaRock()
        {
            rock = new Animation("resources/sprites/ManaRock.png", 64, 64);
            SetAnimation(rock);
            GetAnimation().Start();
        }

        public IActor Interction(List<IActor> list)
        {
            foreach (IActor actor in list)
            {
                if (actor == this) continue;
                if (!(actor is Player)) continue;
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
            IActor actor = Interction(GetWorld().GetActors());
            if (actor != null)
            {
                IWizard wizard = (IWizard)actor;
                wizard.ChangeMana(1);

            }
        }
    }
}

