using Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Strategies
{
    public class ModifiedSpeedStrategy : ISpeedStrategy
    {
        
        
        private double multi;

        public ModifiedSpeedStrategy(double multi)
        {
            this.multi = multi;

        }

        public double GetSpeed(double speed)
        {
            return multi * speed;
        }

        //------------------------------------------------------------//
        /*
        IMovable movable;
        public ModifiedSpeedStrategy(IMovable movable)
        {
            this.movable = movable;
        }

        public double GetSpeed(double speed)
        {
            throw new NotImplementedException();
        }*/
    }
}
