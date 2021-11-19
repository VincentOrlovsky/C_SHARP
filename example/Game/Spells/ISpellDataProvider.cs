using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Spells
{
    public interface ISpellDataProvider
    {
        Dictionary<string, SpellInfo> GetSpellInfo();
        Dictionary<string, int> GetSpellEffects();

    }
}
