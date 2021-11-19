using Game.Actors;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Game.Commands
{
    class Move : Command
    { 
        private IActor actor;
        private int dy;
        private int dx;
        private double step;
        private double zvysok;
        
        public Move(IMovable movable, double step, int dx, int dy)
        {
            this.dx = dx;
            this.dy = dy;
            this.step = step;
            zvysok = 0;

            if (movable != null)
            {
                this.actor = (IActor)movable;
            }
            
        }
        

        public void Execute()
        {
            zvysok += step % 1;
            double p = zvysok / 1;
            zvysok -= p;
            actor.SetPosition(actor.GetX() + dx, actor.GetY() + dy * (int)(step+p)/1);
            
            if (actor.GetWorld().IntersectWithWall(actor))  // osetrenie prechdzania cez steny
            {
                actor.SetPosition(actor.GetX() - dx, actor.GetY() - dy * (int)step/1);
            }
        }
    }
}
