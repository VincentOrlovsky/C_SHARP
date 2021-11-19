using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Factories
{
    public class SpellEffectFactory 
    {
        public Command Create(string effectName)
        {
            string[] values = effectName.Split('-');
            if (values[0].ToLower() == "damage")
            {
                return new Damage(Int32.Parse(values[1]));
            }
            if (values[0].ToLower() == "heal")
            {
                return new Heal(Int32.Parse(values[1]));
            }
            if (values[0].ToLower() == "dot")
            {
                return new Dot(Int32.Parse(values[1]));
            }
            return null;
        }
    }
}
