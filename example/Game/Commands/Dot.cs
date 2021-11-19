using Game.Actors;
using Game.Spells;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Commands
{
    public class Dot : Command, IDangerousSpell
    {
        private AbstractCharacter target;
        private int nvm;
        private int counter;

        public Dot(int nvm)
        {
            this.nvm = nvm;
        }

        public void Execute()
        {
            if (counter%30 == 0 && counter <= 360)
            {
                target.ChangeHealth(-10);
            }
            counter++;
        }

        public void SetTarget(AbstractCharacter target)
        {
            this.target = target;
        }
    }
}
