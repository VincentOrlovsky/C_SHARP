using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    public class Lever : AbstractActor, IObservable, IUsable
    {
        List<IActor> observers;

        private Animation on;
        private Animation off;


        public Lever(string name)
        {
            SetName(name);

            observers = new List<IActor>();

            on = new Animation("resources/sprites/WoodLeverLeft.png", 32, 16);
            off = new Animation("resources/sprites/WoodLeverRight.png", 32, 16);

            SetAnimation(off);
            GetAnimation().Start();
        }

        public void Toogle()
        {
            if(GetAnimation() == off) SetAnimation(on);
            else SetAnimation(off);
        }

        public void Subscribe(IObserver observer)
        {
            if (observers.Contains((IActor)observer) == false)
            {
                observers.Add((IActor)observer);
            }
        }

        public void Unsubscribe(IObserver observer)
        {
            observers.Remove((IActor)observer);
        }

        public override void Update()
        {
            base.Update();
           
        }

        public void Use(Player user)
        {
            Toogle();
            foreach (Door c in observers)
            {
                c.Notify();
            }
        }
    }
}
