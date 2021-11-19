using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    interface ICharacter : IMovable
    {
        void ChangeHealth(int delta);
        int GetHealth();
        void Die();
        void AddEffect(Command effect);
        void RemoveEffect(Command effect);
    }
}
