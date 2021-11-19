using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Actors
{
    public abstract class AbstractActor : IActor
    {
        private string name;
        private int x;
        private int y;
        private int width;
        private int height;
        private IWorld world;
        private Animation animation;
        private bool isPhysicsEnabled;
        private bool removedFromWorld;

        public AbstractActor()
        {
            this.name = "";
            this.isPhysicsEnabled = false;
            this.x = 0;
            this.y = 0;
            this.removedFromWorld = false;

        }
        public AbstractActor(string name)
        {
            this.name = name;
            this.isPhysicsEnabled = false;
            this.x = 0;
            this.y = 0;
            this.removedFromWorld = false;
        }

        public string GetName()
        {
            return name;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }

        public int GetWidth()
        {
            return animation.GetWidth();
        } 
        public int GetHeight()
        {
            return animation.GetHeight();
        }

        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void AddedToWorld(IWorld world)
        {
            this.world = world;
        }

        public Animation GetAnimation()
        {
            return animation;
        }

        public void SetAnimation(Animation animation)
        {
            this.height = animation.GetHeight();
            this.width = animation.GetWidth();
            this.animation = animation;
        }

        public bool IntersectsWithActor(IActor other)
        {
            if ((other.GetX() > this.GetX() + this.GetWidth()) ||
                (other.GetX() + other.GetWidth() < this.GetX()) ||
                (other.GetY() > this.GetY() + this.GetHeight()) ||
                (other.GetY() + other.GetHeight() < this.GetY()))
            {
                return false;
            }
            return true;
        }

        public void SetPhysics(bool isPhysicsEnabled)
        {
            this.isPhysicsEnabled = isPhysicsEnabled;
        }
        public bool IsAffectedByPhysics()
        {
            if (isPhysicsEnabled==true) return true;
            return false;
        }
        public void RemoveFromWorld()
        {
            removedFromWorld = true;
        }

        public bool RemovedFromWorld()
        {
            if (removedFromWorld == true) return true;
            return false;
        }

        public virtual void Update()
        {

        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public IWorld GetWorld()
        {
            return this.world;
        }

        public void OnAddedToWorld(IWorld world)
        {
            this.world = world;
        }
    }
}
