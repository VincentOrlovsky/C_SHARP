using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    public class Box : AbstractCharacter, ICharacter, IPushable
    {
        private Animation box;

        private Player player;

        public Box()
        {
            box = new Animation("resources/sprites/Box.png", 32, 32);
            SetAnimation(box);
            GetAnimation().Start();
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public IActor Interction(List<IActor> list)
        {
            foreach (IActor actor in list)
            {
                if (actor == this) continue;
                
                if (IntersectsWithActor(actor) && actor is AbstractCharacter)
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
            if (actor is Player)
            {
                
                
                if (GetY() < actor.GetY()-actor.GetHeight()&& GetX()<actor.GetX() && GetX()+GetWidth() > actor.GetX()) actor.SetPosition(actor.GetX(), actor.GetY() - 1);
                else if (GetX() < actor.GetX()) SetPosition(GetX() - 1, GetY());
                else SetPosition(GetX() + 1, GetY());
            }
        }
    }
}
