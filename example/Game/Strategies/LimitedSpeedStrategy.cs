using Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Strategies
{
    public class LimitedSpeedStrategy : ISpeedStrategy
    {
        private double maxSpeed;

        public LimitedSpeedStrategy( double maxSpeed)
        {
            
            this.maxSpeed = maxSpeed;
        }

        public double GetSpeed(double speed)
        {
            return speed < maxSpeed ? speed : maxSpeed;   //max speed settings
        }
    }
}
