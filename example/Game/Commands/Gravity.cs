using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Commands
{
    class Gravity : IPhysics
    {
        private IWorld world;
        private Fall<IActor> fall;

        public Gravity()
        {
            this.fall = new Fall<IActor>();
        }
        
        public void Execute()
        {
            //IEnumerable<IActor> actors = 
            world.GetActors().Where(t => t.IsAffectedByPhysics()).ToList().ForEach(t => fall.Execute(t));
        }

        public void SetWorld(IWorld world)
        {
            this.world = world;
        }
    }
}
