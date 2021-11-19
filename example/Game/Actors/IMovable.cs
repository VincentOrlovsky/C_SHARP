using Game.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    interface IMovable
    {
        public void SetSpeedStrategy(ISpeedStrategy speedStrategy);

        public double GetSpeed(double speed); //(double speed)
    }
}
