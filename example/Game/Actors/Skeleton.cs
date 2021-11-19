using Game.Actors;
using Game.Commands;
using Game.Spells;
using Game.Strategies;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Game.Actors
{
    class Skeleton : AbstractCharacter, IMovable
    {
        private double speed;

        private Animation walk;
        private bool faceingRight;
        private Command moveRight;
        private Command moveLeft;
        private Command jump;

        
        IMessage message1;

        private Player player;

        

        Random random = new Random(); //initialize pseudorandom number generator, do this only once

        //int x = random.Next(min, max); //get random number from the given range

        public Skeleton()
        {
            walk = new Animation("resources/sprites/enemy.png", 33, 47);
            SetAnimation(walk);
            GetAnimation().Start();
            
            faceingRight = true;

            SetHealth(60);

            speed = 1;
            SetSpeedStrategy(new NormalSpeedStrategy());
        
            moveLeft = new Move(this, GetSpeed(speed), -1, 0);
            moveRight = new Move(this, GetSpeed(speed), 1, 0);
            jump = new Jump(this, 20, 1);

            message1 = new Message(this.GetName(), 0, -20, 10, new Color(255, 0, 0), MessageDuration.Indefinite);
            message1.SetAnchorPoint(this);
        }
        /*
        public void SetPlayer(IActor player)
        {
            this.player = player;
        }*/

        private void changeDirection(bool faceRight)
        {
            if (faceingRight == true)
            {
                walk.FlipAnimation();
                faceingRight = false;
                moveLeft.Execute();
            }
            else 
            {
                walk.FlipAnimation();
                faceingRight = true;
                moveRight.Execute();
            }                
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

        public override void Die()
        {
            base.Die();
            RemoveFromWorld();
            GetWorld().RemoveMessage(message1);
        }

        public override void Update()
        {
            

            player = (Player)GetWorld().GetActors().Find(a => a is Player);
            if (IntersectsWithActor(player))
            {
                player.ChangeHealth(-1);
            }

            IActor actor = Interction(GetWorld().GetActors());
            if (actor is ISpell)
            {
                ISpell spell = (ISpell)GetWorld().GetActors().Find(a => a==actor);
                ChangeHealth(-20);
                spell.RemoveFromWorld();
                
            }


            if (Math.Abs(player.GetX() - this.GetX())<150 && Math.Abs(player.GetY() - this.GetY()) < 50)
            {
                //following = false;
                if(player.GetX()< this.GetX())
                {
                    GetAnimation().Start();
                    if (faceingRight == true)
                    {
                        walk.FlipAnimation();
                        faceingRight = false;
                    }
                    moveLeft.Execute();
                }
                else if (player.GetX() > this.GetX())
                {
                    GetAnimation().Start();
                    if (faceingRight == false)
                    {
                        walk.FlipAnimation();
                        faceingRight = true;
                    }
                    moveRight.Execute();
                }
                else GetAnimation().Stop();
                /*
                if (player.GetY() < this.GetY())
                {
                    jump.Execute();
                }*/
                

            }
            else
            {
                GetAnimation().Start();
                int x = random.Next(0, 1000);
                if (x < 5)
                {
                    changeDirection(faceingRight);
                }             
                else
                {
                    if (faceingRight == true)
                    {
                        moveRight.Execute();
                    }
                    else moveLeft.Execute();
                }
            }           
        }
    }
}
