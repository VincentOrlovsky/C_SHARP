using Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Strategies
{
    public class NormalSpeedStrategy : ISpeedStrategy
    {
        public NormalSpeedStrategy()
        {        
        }
        public double GetSpeed(double speed)
        {
            return speed;
        }
    }
}
