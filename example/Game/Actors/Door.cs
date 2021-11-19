using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    public class Door : AbstractActor, IObserver
    {
        private Animation closedDoor;
        private Animation openedDoor;

        private IWorld world;

        public Door(string name)
        {
            SetName(name);
            closedDoor = new Animation("resources/sprites/ClosedChainDoor.png", 16, 64);
            openedDoor = new Animation("resources/sprites/OpenedChainDoor.png", 16, 64);
            SetAnimation(closedDoor);
            GetAnimation().Start();
            
        }

        public void SetObservable(IObservable observable)
        {
            observable.Subscribe(this);
        }


        public void Notify()
        {
            
            Toogle();
        }

        public void LockDoor(IWorld world)
        {
            this.world = world;
            SetAnimation(closedDoor);
            for (int i = 0; i < (closedDoor.GetHeight() / 16); i++)
            {
                world.SetWall(this.GetX() / 16, this.GetY() / 16 + i, true);
            }
        }

        public void Toogle()
        {
            if (GetAnimation() == closedDoor)
            {
                SetAnimation(openedDoor);
                for (int i = 0; i < (closedDoor.GetHeight() / 16); i++)
                {
                    world.SetWall(this.GetX() / 16, this.GetY() / 16 + i, false);
                }
            }
            else
            {
                SetAnimation(closedDoor);
                for (int i = 0; i < (closedDoor.GetHeight() / 16); i++)
                {
                    world.SetWall(this.GetX() / 16, this.GetY() / 16 + i, true);
                }
            }
        }

        public override void Update()
        {
            base.Update();

            
        }
    }
}
