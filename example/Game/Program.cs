using Game.Actors;
using Game.Commands;
using Game.Factories;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("whatever", 1024, 768,true);  //vytvaranie okna hry
            
            container.AddWorld("resources/maps/map03.tmx");
            container.AddWorld("resources/maps/map04.tmx");
            container.AddWorld("resources/maps/map05.tmx");
            
            /*
            Console.WriteLine(container.AddWorld("resources/maps/map03.tmx"));
            Console.WriteLine(container.AddWorld("resources/maps/map04.tmx"));
            Console.WriteLine(container.AddWorld("resources/maps/map05.tmx"));
            */


            // pridanie ActorFactory do sveta
            //world.SetFactory(new SpellEffectFactory());

            //container.SetMap("resources/maps/map04.tmx");  //nacitanie mapy

            container.SetEndGameMessage(new Message("Congratulations!!! \nYou competed this amazing game! \nHURRAY",100,100), true);   // vyherna sprava
            container.SetEndGameMessage(new Message("You lost! \nLoooooser",100,100), false);  // preherna sprava

            for(int i = 0; i < container.GetWorldCount(); i++)
            {
                IWorld world = container.GetWorld(i);
                world.SetFactory(new ActorFactory());
                Gravity gravity = new Gravity();
                container.GetWorld(i).SetPhysics(gravity);

                Action<IWorld> setLeverAndPressurePlate = world => {
                    Lever lever = (Lever)world.GetActors().Find(a => a.GetName() == "Lever1");
                    Door leverDoor = (Door)world.GetActors().Find(a => a.GetName() == "ChainDoorDown");
                    lever.Subscribe(leverDoor);
                    leverDoor.LockDoor(world);

                    PressurePlate pressureplate = (PressurePlate)world.GetActors().Find(a => a.GetName() == "WoodenPressurePlate");
                    Door pressureplateDoor = (Door)world.GetActors().Find(a => a.GetName() == "ChainDoorUp");
                    pressureplate.Subscribe(pressureplateDoor);
                    pressureplateDoor.LockDoor(world);

                    Player player = (Player)world.GetActors().Find(actor => actor is Player);
                    Box box = (Box)world.GetActors().Find(actor => actor is Box);
                    box.SetPlayer(player);

                    WarpPortal warp1 = (WarpPortal)world.GetActors().Find(a => a.GetName() == "WarpIn");
                    WarpPortal warp2 = (WarpPortal)world.GetActors().Find(a => a.GetName() == "WarpOut");
                    warp1.SetPortal(warp2);
                    warp2.SetPortal(warp1);

                    world.ShowInventory(player.GetBackpack());
                };

                Action<IWorld> setCamera = world => {
                    world.CenterOn(world.GetActors().Find(a => a.GetName() == "player"));
                    world.GetActors().ForEach(actor => actor.SetPhysics(true));
                };
                /*
                Action<IWorld> setPlayerForEnemies = world => {
                    Player player = (Player)world.GetActors().Find(actor => actor is Player);
                    //List<IActor> skel = world.GetActors().FindAll(actor => actor is Skeleton);
                    Skeleton enemy = (Skeleton)world.GetActors().Find(actor => actor is Skeleton);
                    enemy.SetPlayer(player);
                };*/

                world.AddInitAction(setLeverAndPressurePlate);
                //world.AddInitAction(setPlayerForEnemies);
                world.AddInitAction(setCamera);
            }

            Console.WriteLine(container.GetWorldCount().ToString());

            container.Run();
        }
    }
}

