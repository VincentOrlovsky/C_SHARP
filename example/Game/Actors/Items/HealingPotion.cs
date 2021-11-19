using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors.Items
{
    public class HealingPotion : AbstractActor, IItem, IUsable
    {
        private int heal;
        private bool used;

        private Animation potion;
        private Animation healingPotion;


        public HealingPotion()
        {
            potion = new Animation("resources/sprites/items/Potion.png", 8, 12);
            healingPotion = new Animation("resources/sprites/items/HealingPotion.png", 8, 12);

            SetAnimation(healingPotion);
            GetAnimation().Start();

            heal = 20;
            used = false;
        }

        public void Use(Player user)
        {
            if (!used)
            {
                user.ChangeHealth(heal);
                SetAnimation(potion);
            }
        }
    }
}
