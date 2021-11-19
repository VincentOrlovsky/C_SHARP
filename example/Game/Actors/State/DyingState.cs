using Merlin2d.Game;
using Merlin2d.Game.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors.State
{
    public class DyingState : IPlayerState
    {
        public DyingState(AbstractCharacter player)
        {
            player.SetAnimation(new Animation("resources/sprites/TombStone.png", 32, 64));
        }

    }
}
