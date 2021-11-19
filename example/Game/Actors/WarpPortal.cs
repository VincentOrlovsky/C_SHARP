using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    public class WarpPortal : AbstractActor
    {
        private Animation portal;

        private WarpPortal other;
        private string name;

        public WarpPortal(string name)
        {
            SetName(name);
            portal = new Animation("resources/sprites/Warp/WarpBlack.png", 32, 48);
            SetAnimation(portal);
            GetAnimation().Start();
            GetAnimation().FlipAnimation();
        }

        public void SetPortal(WarpPortal other)
        {
            this.other = other;
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
            if (actor != null && GetName() == "WarpIn")
            {
                Player player = (Player)GetWorld().GetActors().Find(a => a == actor);
                player.SetPosition(other.GetX(), other.GetY());
            }
        }
    }
}
