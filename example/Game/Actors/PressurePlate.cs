using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    public class PressurePlate : AbstractActor, IObservable
    {
        List<IActor> observers;

        private Animation unpressed;
        private Animation pressed;

        private bool pressure;
        private bool opened;

        public PressurePlate(string name)
        {
            SetName(name);

            observers = new List<IActor>();

            unpressed = new Animation("resources/sprites/WoodenPressurePlate.png", 32, 6);
            pressed = new Animation("resources/sprites/PressedWoodenPressurePlate.png", 32, 6);

            SetAnimation(unpressed);
            GetAnimation().Start();

            pressure = false;
            opened = false;


        }

        public void Toogle()
        {
            if (GetAnimation() == pressed) SetAnimation(unpressed);
            else SetAnimation(pressed);
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

        public IActor Interction(List<IActor> list)
        {
            foreach (IActor actor in list)
            {
                if (actor == this) continue;
                if (IntersectsWithActor(actor))
                {
                    return actor;
                }
            }

            return null;
        }

        public void OpenClose(bool isopened, bool ispressure)
        {
            if(!isopened && ispressure)
            {
                Toogle();
                foreach (Door c in observers)
                {
                    c.Notify();
                }
                opened = true;
            }
            else if(isopened && !ispressure)
            {
                Toogle();
                foreach (Door c in observers)
                {
                    c.Notify();
                }
                opened = false;
            }
           

            
        }

        public override void Update()
        {
            base.Update();

            IActor actor = Interction(GetWorld().GetActors());
            if (actor is ICharacter)
            {
                pressure = true;
            }
            else
            {
                pressure = false;
            }
            OpenClose(opened, pressure);
        }
    }
}
