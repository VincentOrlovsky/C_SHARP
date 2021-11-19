using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors.Items
{
    public class Key : AbstractActor, IItem, IUsable
    {
        private Animation key;
        private Player user;

        public Key()
        {
            key = new Animation("resources/sprites/items/Key.png", 20, 20);
            SetAnimation(key);
            GetAnimation().Start();

        }


        public void Use(Player user)
        {
            this.user = user;
            IActor actor = user.Interction(user.GetWorld().GetActors());
            if (actor is Portal)
            {
                Portal portal = (Portal)user.GetWorld().GetActors().Find(a => a == actor);
                if (portal.IsNextLevel())
                {
                    portal.Open();
                    
                }
            }
        }
    }
}
