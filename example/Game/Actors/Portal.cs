using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    public class Portal : AbstractActor
    {
        private string name;

        private Animation closedPortal;
        private Animation portal;

        private bool opened;
        private bool nextLevel;


        public Portal(string name)
        {
            this.name = name;

            if (name == "YellowPortal") closedPortal = new Animation("resources/sprites/Portals/PortalYellow.png", 64, 64);
            if (name == "GreenPortal") closedPortal = new Animation("resources/sprites/Portals/PortalGreen.png", 64, 64);
            if (name == "RedPortal") closedPortal = new Animation("resources/sprites/Portals/PortalRed.png", 64, 64);

            portal = new Animation("resources/sprites/Portals/Portal.png", 64, 64);

            if(name != "Portal")
            {
                nextLevel = true;
                opened = false;
                SetAnimation(closedPortal);
                GetAnimation().Start();
            }
            else
            {
                nextLevel = false;
                opened = true;
                SetAnimation(portal);
                GetAnimation().Start();
            }
            

        }

        public bool IsNextLevel()
        {
            return nextLevel;
        }

        public bool IsOpened()
        {
            return opened;
        }

        public void Open()
        {
            opened = true;
        }

        public void Toogle()
        {
            if (opened) SetAnimation(portal);
            else SetAnimation(closedPortal);
        }

        public override void Update()
        {
            base.Update();
            if(opened && nextLevel)
            {
                SetAnimation(portal);
            }
        }

    }
}
