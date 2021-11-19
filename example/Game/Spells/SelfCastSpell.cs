using Game.Actors;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Spells
{
    public class SelfCastSpell : AbstractActor, ISpell
    {
        private int cost;
        private List<Command> effects;
        private IWizard wizard;


        public SelfCastSpell(IWizard wizard, int cost)
        {
            this.cost = cost;
            this.wizard = wizard;

        }
        public ISpell AddEffect(Command effect)
        {
            effects.Add(effect);
            return this;
        }

        public void AddEffects(IEnumerable<Command> effects)
        {
            this.effects = effects.ToList();
        }

        public void Cast()
        {
            if (wizard.GetMana() < cost) return;
            wizard.ChangeMana(-cost);
            foreach (Command e in effects)
            {
                AbstractCharacter self = (AbstractCharacter)wizard;
                IDangerousSpell spell = (IDangerousSpell)e;
                spell.SetTarget(self);
                self.AddEffect(e);
            }
        }

        public int GetCost()
        {
            return cost;
        }
    }
}
