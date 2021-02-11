using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMan_Windows_Port.Menu
{
     public abstract class MenuVariable
    {
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
        public string[] menuList;







    }
}
