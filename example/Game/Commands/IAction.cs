using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Commands

{
    public interface IAction<T>
    {
        void Execute(T t);
    }
}
