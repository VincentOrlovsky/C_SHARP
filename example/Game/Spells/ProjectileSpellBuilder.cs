using Game.Actors;
using Game.Factories;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Spells
{
    class ProjectileSpellBuilder : ISpellBuilder
    {
        private int cost;
        private IWizard caster;
        private Animation animation;
        private ISpell spell;
        private List<Command> effects;
        private SpellEffectFactory factory;

        public ProjectileSpellBuilder()
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
            ISpell spell = new ProjectileSpell(caster,cost,animation);
            spell.AddEffects(effects);
            return spell;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            this.animation = animation;
            return this;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            this.cost = cost;
            return this;
        }
    }
}
