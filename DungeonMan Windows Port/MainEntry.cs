using DungeonMan_Windows_Port.World;
using DungeonMan_Windows_Port.Menu;
using System;
using DungeonMan_Windows_Port.Entity.Player;

namespace DungeonMan_Windows_Port
{
    class MainEntry
    {

        public static string path = "C:/Users/mariu/Desktop/text.txt";

        public OverWorld ov;
        public Player player;


        public MainEntry()
        {
            player = new Player(100, 15, 0, true);
            setup();
        }


        public void setup()
        {
            ov = new OverWorld(player);
        }


        public static void space()
        {
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            new MainEntry();
        }
    }
}
