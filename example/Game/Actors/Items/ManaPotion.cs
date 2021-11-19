using Merlin2d.Game;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors.Items
{
    public class ManaPotion : AbstractActor, IItem, IUsable
    {
        private int mana;
        private bool used;

        private Animation potion;
        private Animation manaPotion;


        public ManaPotion()
        {
            potion = new Animation("resources/sprites/items/Potion.png", 8, 12);
            manaPotion = new Animation("resources/sprites/items/ManaPotion.png", 8, 12);

            SetAnimation(manaPotion);
            GetAnimation().Start();

            mana = 20;
            used = false;
        }

        public void Use(Player user)
        {
            if (!used)
            {
                user.ChangeMana(mana);
                SetAnimation(potion);
            }
        }
    }
}
