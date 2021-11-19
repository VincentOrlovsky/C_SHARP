using Merlin2d.Game;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors.Items
{
    public class Poison : AbstractActor, IItem, IUsable
    {
        private int damage;
        private bool used;

        private Animation potion;
        private Animation poison;


        public Poison()
        {
            potion = new Animation("resources/sprites/items/Potion.png", 8, 12);
            poison = new Animation("resources/sprites/items/Poison.png", 8, 12);

            SetAnimation(poison);
            GetAnimation().Start();

            damage = -1000;
            used = false;
        }

        public void Use(Player user)
        {
            if (!used)
            {
                user.ChangeHealth(damage);
                SetAnimation(potion);
            }
        }
    }
}
