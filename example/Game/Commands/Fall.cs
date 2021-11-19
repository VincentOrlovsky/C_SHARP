using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Game.Commands
{
    public class Fall<T> : IAction<T> where T: IActor
    {
        private int speed;

        public Fall()
        {
            speed = 2;
        }
        public void Execute(T t)
        {                      
            t.SetPosition(t.GetX(), t.GetY() + speed);
            if (t.GetWorld().IntersectWithWall(t))
            {
                t.SetPosition(t.GetX(), t.GetY() - speed);
            }           
        }
    }
}
