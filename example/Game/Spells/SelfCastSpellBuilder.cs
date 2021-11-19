using Game.Actors;
using Game.Factories;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Spells
{
    public class SelfCastSpellBuilder : ISpellBuilder
    {
        private int cost;
        private IWizard caster;
        private Animation animation;
        private ISpell spell;
        private List<Command> effects;
        private SpellEffectFactory factory;

        public SelfCastSpellBuilder()
        {
            effects = new List<Command>();
            factory = new SpellEffectFactory();
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            effects.Add(factory.Create(effectName));
            return this;
        }

        public ISpell CreateSpell(IWizard caster)
        {
            this.caster = caster;
            ISpell spell = new SelfCastSpell(caster, cost);
            spell.AddEffects(effects);
            return spell;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
                throw new NotImplementedException();
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            this.cost = cost;
            return this;
        }
    }
}
