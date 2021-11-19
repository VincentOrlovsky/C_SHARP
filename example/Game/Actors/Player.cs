using Game.Actors;
using Game.Actors.State;
using Game.Commands;
using Game.Spells;
using Game.Strategies;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;

namespace Game.Actors
{

    public class Player : AbstractCharacter, IMovable, IWizard
    {
        private IPlayerState state;

        private Animation walk;
        
        private Command moveRight;
        private Command moveLeft;
        private Command jump;

        private Backpack backpack;

        private int non;

        private bool faceingRight;

        private int mana;
        private int manaLoader;

        private double speed;

        private int offsetX ;
        

        IMessage message1;
        IMessage message2;




        public Player()
        {
            state = new LivingState();
        }

        
        public Player(string name)
        {
            SetName(name);

            walk = new Animation("resources/sprites/player.png", 27, 47);

            SetAnimation(walk);
            GetAnimation().Start();
            GetAnimation().Stop();

            SetHealth(1000);

            backpack = new Backpack(10);

            non = 0;

            speed = 10;
            SetSpeedStrategy(new NormalSpeedStrategy());

            mana = 200;
            manaLoader = 0;

            offsetX = 0;
            

            faceingRight = true;

            moveLeft = new Move(this, GetSpeed(speed), -1, 0);
            moveRight = new Move(this, GetSpeed(speed), 1, 0);
            jump = new Jump(this, 20, 1);

            message1 = new Message(this.GetName(), offsetX, -20, 10, new Color(255, 0, 0), MessageDuration.Indefinite);
            message1.SetAnchorPoint(this);
            message2 = new Message(this.GetName(), offsetX, -10, 10, new Color(0, 0, 255), MessageDuration.Indefinite);
            message2.SetAnchorPoint(this);

        }

        public void Cast(ISpell spell)
        {
            spell.Cast();
        }

        public void CastSpell(string name)
        {
            ISpellDirector director = new SpellDirector(SpellDataProvider.GetInstance(), this);
            ISpell spell = director.Build(name);
            Cast(spell);
        }

        public void ChangeMana(int delta)
        {
            mana += delta;
            if (mana < 0) mana = 0;
        }

        public bool IsFacingRight()
        {
            return faceingRight;
        }

        public int GetMana()
        {
            return mana;
        }

        public Backpack GetBackpack()
        {
            return backpack;
        }

        public IActor Interction(List<IActor> list)
        {
            foreach(IActor actor in list)
            {
                if (actor == this) continue;
                if (actor is Skeleton) continue;
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
            GetWorld().SetEndCondition(world => MapStatus.Failed);
            state = new DyingState(this);
        }

        

        public override void Update() //override
        {
            base.Update(); 

            if(state is DyingState)
            {
                GetWorld().RemoveMessage(message1);
                GetWorld().RemoveMessage(message2);
                return;
            }

            message1.SetText("Live:" + GetHealth().ToString());
            GetWorld().AddMessage(message1);
            message2.SetText("Mana:" + GetMana().ToString());
            GetWorld().AddMessage(message2);

            if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
            {
                GetAnimation().Start();
                if (faceingRight == false)
                {
                    walk.FlipAnimation();
                }
                
                faceingRight = true;
                moveRight.Execute();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
            {
                GetAnimation().Start();
                if (faceingRight == true)
                {
                    walk.FlipAnimation();
                }
                faceingRight = false;
                moveLeft.Execute();
            }
            else GetAnimation().Stop();

            if (Input.GetInstance().IsKeyPressed(Input.Key.UP))
            {
                if(non == 0)
                {
                    jump.Execute();
                    non = 10;
                }
                
            }
            if (non != 0) non--;

            if (manaLoader % 2000 == 0 && mana < 50) mana++;
            manaLoader++;

            if (Input.GetInstance().IsKeyPressed(Input.Key.Q))
            {
                CastSpell("fireball");
            }
            else if(Input.GetInstance().IsKeyPressed(Input.Key.W))
            {
                CastSpell("frostball");
            }
            else if (Input.GetInstance().IsKeyPressed(Input.Key.E))
            {
                CastSpell("healspell");
            }

            IActor actor = Interction(GetWorld().GetActors());
            if (actor != null)
            {

                if (actor is IUsable && actor is IItem)
                {
                    if (Input.GetInstance().IsKeyPressed(Input.Key.S))
                    {
                        IItem item = (IItem)GetWorld().GetActors().Find(a => a == actor);
                        backpack.AddItem(item);           
                        item.RemoveFromWorld();
                    }
                }

                if (actor is IUsable)
                {
                    if (Input.GetInstance().IsKeyPressed(Input.Key.SPACE))
                    {
                        IUsable usable = (IUsable)GetWorld().GetActors().Find(a => a == actor);
                        usable.Use(this);
                    }
                }

                if (actor is Portal)
                {
                    Portal portal = (Portal)GetWorld().GetActors().Find(a => a == actor);
                    if(portal.IsNextLevel() && portal.IsOpened())
                    {
                        if (Input.GetInstance().IsKeyPressed(Input.Key.SPACE))
                        {
                            GetWorld().SetEndCondition(world => MapStatus.Finished);
                        }
                    }
                    
                }
                /*
                if(actor is ISpell)
                {
                    ISpell spell = (ISpell)GetWorld().GetActors().Find(a =>  a==actor);
                } */
            }

            if (Input.GetInstance().IsKeyPressed(Input.Key.A))
            {
                backpack.ShiftLeft();
            }
            if (Input.GetInstance().IsKeyPressed(Input.Key.D))
            {
                backpack.ShiftRight();
            }
            if (Input.GetInstance().IsKeyPressed(Input.Key.Z))
            {
                IUsable item = (IUsable)backpack.GetItem();
                if(item != null)
                {
                    item.Use(this);
                }
                
            }
            if (Input.GetInstance().IsKeyPressed(Input.Key.X))
            {
                IActor item = (IActor)backpack.GetItem();
                item.OnAddedToWorld(GetWorld());
            }





            //state.Update();

        }
        /*
        public override void Die()
        {
            base.Die();

            state = new DyingState(this);
        }*/

        
    }
}
