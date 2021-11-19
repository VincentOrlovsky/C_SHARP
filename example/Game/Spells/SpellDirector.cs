using Game.Actors;
using Merlin2d.Game;
using System.Collections.Generic;

namespace Game.Spells
{
    public class SpellDirector : ISpellDirector
    {
        Dictionary<string, SpellInfo> spells;
        Dictionary<string, int> effectCost;
        //+referencia na wizarda
        public IWizard wizard;

       

        public SpellDirector(ISpellDataProvider provider, IWizard wizard)
        {
            spells = provider.GetSpellInfo();  //30:32 min
            effectCost = provider.GetSpellEffects();
            this.wizard = wizard;
            
        }

        public ISpell Build(string spellName)
        {
            int cost = 0;

            ISpellBuilder builder;

            if (spells[spellName].SpellType == SpellType.Projectile)
            {
                builder = new ProjectileSpellBuilder();
                builder.SetAnimation(new Animation(spells[spellName].AnimationPath, spells[spellName].AnimationWidth, spells[spellName].AnimationHeight)); //new Animation("aaa", 1, 1) 
                foreach (string effect in spells[spellName].EffectNames)
                {
                    builder.AddEffect(effect);
                    cost += effectCost[effect];
                }
            }
            else
            {
                builder = new SelfCastSpellBuilder();
                foreach (string effect in spells[spellName].EffectNames)
                {
                    builder.AddEffect(effect);
                    cost += effectCost[effect];
                }
            }
            builder.SetSpellCost(cost);
            return builder.CreateSpell(wizard);
        }
    }
}
