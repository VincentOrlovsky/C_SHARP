using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Spells
{
    public interface ISpell : IActor
    {
        ISpell AddEffect(Command effect);
        void AddEffects(IEnumerable<Command> effects);
        int GetCost();
        void Cast();

    }
}
