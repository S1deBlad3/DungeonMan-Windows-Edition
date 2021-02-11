using DungeonMan_Windows_Port.Entity.Enemy;
using DungeonMan_Windows_Port.Entity.Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DungeonMan_Windows_Port.World
{
    public class OverWorld
    {

        public Random random;
        private Player player;
        public StandardEnemy enemy;
        public BattleMap bm;
        public FileInfo fi;

        private int selected;
        private bool firstLaunch;
        private bool enterEnterKey = false;
        private bool skipiteration = false;




        //Menu
        private char outLine = '#';
        private string space = " ";
        private char cursor = '*';
        private int size;
        private string[] menuList = {
              "(m)ove",
              "(f)ights",
              "(i)tems",
              "(s)hop",
               "(e)xit",
            "testing"};



        public OverWorld(Player player)
        {

            this.player = player;
            Console.Title = "Dungeon Man";
            //Console.Clear();
            //MainClass.space();
            firstLaunch = true;

            start();

        }


        public void start()
        {


            /*


            fi = new FileInfo(MainEntry.path);

            //Console.WriteLine(fi.Length);



            if (fi.Length <= 3)
            {

                Console.WriteLine("Welome stranger, what is your name");
                //Console.WriteLine(player.name);
                player.name = Console.ReadLine();

                if (player.name.Length >= 3)
                {
                    System.IO.File.WriteAllText(MainEntry.path, player.name);
                }
                else
                {


                    Console.WriteLine("Too short name");

                    start();
                }


            }
            else
            {

                String[] prevName = System.IO.File.ReadAllLines(MainEntry.path);

                player.name = prevName[0];

            }


            Console.WriteLine("{0} what would you like to do?", player.name);

            */

            MainLoop();

        }


        public void MainLoop()
        {


            player.debugScreen();

            //Selected Logic


            if (firstLaunch)
            {
                ContextMenu();
                selected = 0;
                firstLaunch = false;
            }

            keykontroll();





        }

        private void ContextMenu()
        {


            /*
             ############
             # Move ####
             * Attack ###
             * Items ###
             * */

            //Console.Clear();

            MainEntry.space();



            player.debugScreen();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("#############");

            for (int i = 0; i < menuList.Length; i++)
            {
                Console.Write(outLine + space + space);


                //Cursor Logic

                if (selected == 0 && i == 0)
                {
                    Console.Write(cursor);
                }



                if (i == 1)
                {
                    if (selected == 1)
                    {


                        Console.Write(cursor);


                    }



                }

                if (i == 2)
                {
                    if (selected == 2)
                    {

                        Console.Write(cursor);
                    }




                }

                if (i == 3)
                {
                    if (selected == 3)
                    {

                        Console.Write(cursor);
                    }




                }

                if (i == 4)
                {
                    if (selected == 4)
                    {
                        Console.Write(cursor);
                    }
                }

                if (i == 5)
                {
                    if (selected == 5)
                    {
                        Console.Write(cursor);
                    }
                }







                Console.Write(menuList[i]);

                size = menuList[i].Length;

                Console.Write(space);

                for (int padd = size; padd < 9; padd++)
                {
                    Console.Write(outLine);
                }


                Console.WriteLine();
                Console.WriteLine("#############");
                size = 0;
            }




            keykontroll();



        }


        private void keykontroll()
        {

            var keyTyped = Console.ReadKey();

            if (selected > menuList.Length)
            {
                selected = 0;
                ContextMenu();
            }
            if (selected < 0)
            {
                selected = menuList.Length;
                ContextMenu();
            }


            if (keyTyped.Key == ConsoleKey.DownArrow)
            {

                selected += 1;
                ContextMenu();

            }
            else if (keyTyped.Key == ConsoleKey.UpArrow)
            {

                selected -= 1;
                ContextMenu();


            }
            else if (keyTyped.Key == ConsoleKey.Enter)
            {
                enterEnterKey = true;
                contextDecide();
            }



        }



        private void contextDecide()
        {


            switch (selected)
            {
                case 0:

                    Console.WriteLine("Working");

                    random = new Random();
                    int chance;
                    chance = random.Next(0, 10);
                    int num = random.Next(0, 10);

                    if (num <= chance)
                    {
                        Console.WriteLine("You entered Combat");

                        new BattleMap(player);



                    }
                    else if (num > chance)
                    {
                        Console.WriteLine("You walk around");
                        MainLoop();

                    }


                    break;
                case 1:

                    Console.WriteLine("You son of a bitch, you did it");
                    new BattleMap(player);

                    break;
                case 2:
                    player.Inventory();
                    break;
                case 3:
                    new Shop(player);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;

                case 5:
                    Console.WriteLine("You son of a bitch");
                    new TestingMenu(player);
                    break;
            }






        }



        protected void oldLoop()
        {


            //Console.WriteLine("What would you like to do?");
            //Console.WriteLine("Walk(w), Fight(f), Items(i), Exit(e)");
            String decision;

            decision = Console.ReadLine();

            switch (decision)
            {
                case "Walk":
                case "walk":
                case "w":

                    random = new Random();
                    int chance;
                    chance = random.Next(0, 10);
                    int num = random.Next(0, 10);

                    if (num <= chance)
                    {
                        Console.WriteLine("You entered Combat");

                        new BattleMap(player);



                    }
                    else if (num > chance)
                    {
                        Console.WriteLine("You walk around");

                    }

                    break;

                case "Fight":
                case "fight:":
                case "f":
                    new BattleMap(player);
                    break;

                case "i":
                    player.Inventory();
                    break;

                case "shop":
                case "s":
                    new Shop(player);
                    break;

                case "exit":
                case "Exit":
                case "e":
                    Environment.Exit(0);
                    break;

                case "h":
                    Console.WriteLine(player.getHealth());
                    break;


                default:
                    break;
            }


        }

    }
}
