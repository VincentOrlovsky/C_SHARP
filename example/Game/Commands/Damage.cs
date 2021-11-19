using Game.Actors;
using Game.Spells;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Commands
{
    public class Damage : Command, IDangerousSpell
    {
        private int damage;
        private AbstractCharacter target;

        private bool used;

        public Damage(int damage)
        {
            this.damage = damage;
            used = false;
        }

        public void Execute()
        {
            if (!used)
            {
                target.ChangeHealth(-damage);
                used = true;
            }
        }

        public void SetTarget(AbstractCharacter target)
        {
            this.target = target;
        }
    }
}
