﻿using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    public class Spikes : AbstractActor
    {
        private Animation rock;

        public Spikes()
        {
            rock = new Animation("resources/sprites/Spikes.png", 32, 8);
            SetAnimation(rock);
            GetAnimation().Start();
        }

        public IActor Interction(List<IActor> list)
        {
            foreach (IActor actor in list)
            {
                if (actor == this) continue;
                if (!(actor is AbstractCharacter)) continue;
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
                AbstractCharacter wizard = (AbstractCharacter)actor;
                wizard.ChangeHealth(-1);

            }
        }
    }
}

