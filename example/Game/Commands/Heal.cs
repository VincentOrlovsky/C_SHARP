using Game.Actors;
using Game.Spells;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Commands
{
    public class Heal : Command, IDangerousSpell
    {
        private int heal;
        private AbstractCharacter target;
        private bool used;

        public Heal(int heal)
        {
            this.heal = heal;
            used = false;
        }

        public void Execute()
        {
            if (!used)
            {
                target.ChangeHealth(heal);
                used = true;
            }
        }

        public void SetTarget(AbstractCharacter target)
        {
            this.target = target;
        }
    }
}
