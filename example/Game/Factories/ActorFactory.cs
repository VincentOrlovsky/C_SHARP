using Game.Actors;
using Game.Actors.Items;
using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Factories
{
    public class ActorFactory : IFactory
    {
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            IActor actor;
            if (actorType == "Player")
            {
                actor = new Player(actorName);
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "Enemy")
            {
                actor = new Skeleton();
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "Door")
            {
                actor = new Door(actorName);
                actor.SetPosition(x, y);
                return actor;
            }      
            else if(actorType == "PressurePlate")
            {
                actor = new PressurePlate(actorName);
                actor.SetPosition(x, y);
                return actor;
            }
            else if(actorType == "Lever")
            {
                actor = new Lever(actorName);
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "Box")
            {
                actor = new Box();
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "HealingPotion")
            {
                actor = new HealingPotion();
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "ManaPotion")
            {
                actor = new ManaPotion();
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "Poison")
            {
                actor = new Poison();
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "Portal")
            {
                actor = new Portal(actorName);
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "Key")
            {
                actor = new Key();
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "WarpPortal")
            {
                actor = new WarpPortal(actorName);
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "HealingRock")
            {
                actor = new HealingRock();
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "ManaRock")
            {
                actor = new ManaRock();
                actor.SetPosition(x, y);
                return actor;
            }
            else if (actorType == "Spikes")
            {
                actor = new Spikes();
                actor.SetPosition(x, y);
                return actor;
            }

            return null;
        }
    }
}
