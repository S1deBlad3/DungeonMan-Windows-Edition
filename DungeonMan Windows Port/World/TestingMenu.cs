using DungeonMan_Windows_Port.Entity.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMan_Windows_Port.World
{
    class TestingMenu
    {
       
        private Player player;


        //Variables for Menu

        public bool firstLaunch;
        public int selected;
        public bool enterEnterKey = false;
        public bool skipiteration = false;
        public int SizeOfRow;




        //Menu Characters
        public char outLine = '#';
        public string space = " ";
        public char cursor = '*';
        public int size;
        public string[] menuList = {"item1", "item2", "item3" };



        public TestingMenu(Player player)
        {
            this.player = player;


            ContextMenu(menuList, 5);
        }


        public void ContextMenu(String[] menuItems, int SizeOfRow)
        {


            menuList = new string[menuItems.Length];

            for (int i = 0; i < menuItems.Length; i++)
            {
                menuList[i] = menuItems[i];
            }

            this.SizeOfRow = SizeOfRow;




            /*
             ############
             # Move #####
             * Attack ###
             * Items ####
             * */

            //Console.Clear();




            Console.WriteLine("Debbuging text menu");

            Console.Clear();

            for (int i = 0; i < SizeOfRow; i++)
            {
                Console.Write(outLine);
            }

            Console.WriteLine();

            Console.WriteLine("#############");

            for (int i = 0; i < menuList.Length; i++)
            {
                Console.Write(outLine + space + space);

                //Implement own EventHandler

                for (int k = 0; k < menuList.Length; k++)
                {
                    if (k == i && selected == 0)
                    {
                        Console.Write(cursor);

                    }
                }


                


                Console.Write(menuList[i]);

                size = menuList[i].Length;

                Console.Write(space);

                for (int padd = size; padd < (SizeOfRow - 4); padd++)
                {
                    Console.Write(outLine);
                }


                Console.WriteLine();


                //Console.WriteLine("#############");



                size = 0;
            }

            for (int j = 0; j < SizeOfRow; j++)
            {
                Console.Write(outLine);
            }




            keykontroll();



        }



        //From Here

        public void keykontroll()
        {

            var keyTyped = Console.ReadKey();

            if (selected > menuList.Length)
            {
                selected = 0;
                ContextMenu(menuList, SizeOfRow);
            }
            if (selected < 0)
            {
                selected = menuList.Length;
                ContextMenu(menuList, SizeOfRow);
            }


            if (keyTyped.Key == ConsoleKey.DownArrow)
            {

                selected += 1;
                ContextMenu(menuList, SizeOfRow);

            }
            else if (keyTyped.Key == ConsoleKey.UpArrow)
            {

                selected -= 1;
                ContextMenu(menuList, SizeOfRow);


            }
            else if (keyTyped.Key == ConsoleKey.Enter)
            {
                enterEnterKey = true;
                contextDecide();
            }



        }


        //Override to make own implementation
        public virtual void contextDecide()
        {


            switch (selected)
            {
                case 0:
                    break;
            }


        }

        //To here


    } //End of class






}
