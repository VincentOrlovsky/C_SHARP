using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        public void Unsubscribe(IObserver observer);
    }
}
