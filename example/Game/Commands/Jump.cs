using Game.Actors;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading;

namespace Game.Commands
{
    class Jump : Command
    {
        private IActor actor;       
        private int counter = 0;

        public int dy;
        public int step;

        public Jump(IMovable movable, int step, int dy)
        {
            if (movable != null)
            {
                this.actor = (IActor)movable;
            }

            this.step = step;
            this.dy = dy;
        }
        public void Execute()
        {
            step = 750;
            while (step-- > 0)
            {
                if(counter++%50==0)
                {
                    actor.SetPosition(actor.GetX(), actor.GetY() - 4);
                    if (actor.GetWorld().IntersectWithWall(actor))  // osetrenie prechdzania cez steny
                    {
                        actor.SetPosition(actor.GetX(), actor.GetY() + 4);
                    }
                }

            }
                      
            
        }
    }
}
