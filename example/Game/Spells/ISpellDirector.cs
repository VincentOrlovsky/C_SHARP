using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Spells
{
    public interface ISpellDirector
    {
        ISpell Build(string spellName);
    }
}
