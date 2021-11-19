using Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Spells
{
    public interface IDangerousSpell
    {
        public void SetTarget(AbstractCharacter target);
    }
}
