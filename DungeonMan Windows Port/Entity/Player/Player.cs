using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using DungeonMan_Windows_Port.Entity;
using DungeonMan_Windows_Port.World;

namespace DungeonMan_Windows_Port.Entity.Player
{
    public class Player : Entity
    {

        public static bool firstRunTime;

        public static bool gameOver;

        private string path = "C:/Users/mariu/source/repos/DungeonMan Windows Port/Save/Saves.txt";

        public int wallet = 0;
        public int xp = 0;

        public int money { get; set; }

        public Items.Items weapon = null;
        public bool inMenu;

        public List<Items.Items> inventory = new List<Items.Items>();
        public List<String> invString = new List<string>();
        public List<Items.Items> i2 = new List<Items.Items>();
        private int tempAmount;


        //Amount that is used for calculations
        private int
        basicSwordAmount,
        AdvancedSwordAmount;


        //Amount used for info
        private int
        basicInfo,
        advanedInfo;




        public Player(int health, int attack, int defense) : base(health, attack, defense)
        {

            


            inventory.Add(new Items.Weapons.AdvancedSword());
            inventory.Add(new Items.Weapons.AdvancedSword());
            inventory.Add(new Items.Weapons.BasicSword());
            inventory.Add(new Items.Weapons.AdvancedSword());





            giveMoney(100);

        }

        public Player(int health, int attack, int defense, bool start) : base(health, attack, defense)
        {


            Player.firstRunTime = start;

       

            inventory.Add(new Items.Weapons.AdvancedSword());
            inventory.Add(new Items.Weapons.AdvancedSword());
            inventory.Add(new Items.Weapons.BasicSword());
            inventory.Add(new Items.Weapons.AdvancedSword());





            giveMoney(100);
        }


        public override void fight(int damageDone, Entity enemy)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} did {1} damage to {2}", name, attack, enemy.getName());
            MainEntry.space();

            enemy.health -= attack;
            Console.ResetColor();

            MainEntry.space();

            getInfo();
        }


        public void getInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0} Has {1} Health and will attack for {2} damage.", getName(), getHealth(), getAttack());
            Console.ResetColor();
        }

        public int getXP()
        {
            return xp;
        }

        public int getMoney()
        {
            return money;
        }



        public void debugScreen()
        {

            Console.Clear();

            int preLeft = Console.CursorLeft;
            int preTop = Console.CursorTop;


            Console.CursorLeft = 60;
            Console.CursorTop = 5;

            Console.Write("Health = " + getHealth());
            MainEntry.space();

            Console.CursorLeft = 60;

            Console.Write("Attack = " + getAttack());
            MainEntry.space();

            Console.CursorLeft = 60;

            Console.Write("Wallet = {0}", getMoney());
            MainEntry.space();

            Console.CursorLeft = 60;

            Console.Write("XP = " + getXP());
            MainEntry.space();




            Console.CursorLeft = preLeft;
            Console.CursorTop = preTop;



            Console.WriteLine("Money = {0}", money);

        }



        public void Inventory()
        {

            inMenu = true;

            //checkDuplicated();


            //Check for duplicates, remove them and then make a new list
            convertToString();
            Console.WriteLine("Size of array before removal : " + invString.Count);

            foreach (var x in invString)
            {
                Console.WriteLine("Inventory to string before edit " + x);
            }

            removeDuplicate();

            foreach (var x in invString)
            {
                Console.WriteLine("Inventory after edit : " + x);
            }

            convertToList();

            foreach (var x in i2)
            {

                Console.WriteLine("Items in inventory" + x.Name + "Amount = " + x.Amount);
            }


            //Display info


            foreach (var item in inventory)
            {

                if (item.Name.Equals("Basic Sword"))
                {
                    Console.WriteLine("Item: {0}  Amount: {1}", item.Name, Items.Weapons.BasicSword.basicSwordAmount);
                }
                if (item.Name.Equals("Advanced Sword"))
                {
                    Console.WriteLine("Item: {0}  Amount: {1}", item.Name, Items.Weapons.AdvancedSword.advancedSwordAmount);
                }
                else
                {
                    Console.WriteLine("Item: {0} ", item.Name);
                }



            }





            Console.WriteLine("You can type the name of the item to equip or unequip. Type exit to go back");

            while (inMenu)
            {

                String decision = Console.ReadLine();


                switch (decision)
                {
                    case "basic sword":
                        setWeapon("Basic Sword");
                        break;

                    case "advanced sword":
                        setWeapon("Advanced Sword");
                        break;
                    case "exit":
                        inMenu = false;
                        break;
                }

            }



            new OverWorld(this);


        }


        public void equip(Items.Items item)
        {
            attack += item.getDamage();
            weapon = item;

            Console.WriteLine("You equiped" + item.Name);

        }

        public void unequip(Items.Items item)
        {
            attack -= item.getDamage();
            weapon = null;

            Console.WriteLine("You unequiped" + item.Name);
        }


        public void setWeapon(String TheWeaponToBeEquped)
        {
            for (int i = 0; i < inventory.Count; i++)
            {




                if (inventory[i].Name.Equals(TheWeaponToBeEquped) && weapon == null)
                {


                    equip(inventory[i]);

                    inMenu = false;


                    inMenu = false;

                }

                else if (weapon == (inventory[i]))
                {

                    unequip(inventory[i]);

                    inMenu = false;


                }

                else
                {
                    Console.WriteLine("Error In Loading Inventory");
                }

            }
        }


        public void addItem(Items.Items item, int amount)
        {

            switch (item.Name)
            {
                case "Basic Sword":

                    for (int i = 0; i < amount; i++)
                    {
                        inventory.Add(new Items.Weapons.BasicSword());
                    }
; break;
                case "Advanced Sword":
                    for (int i = 0; i < amount; i++)
                    {
                        inventory.Add(new Items.Weapons.AdvancedSword());
                    }
                    break;
            }



        }


        public void checkDuplicated()
        {

            //int dupeNum = 0;
            //int index;

            foreach (var dupe in inventory)
            {

            }

            // Console.WriteLine(Items.Weapons.BasicSword.amount);
            //  Console.WriteLine(Items.Weapons.AdvancedSword.amount);





        }


        public void giveMoney(int amount)
        {
            money += amount;
        }

        public void removeMoney(int amount)
        {
            money -= amount;
        }


        public void removeDuplicate()
        {




            for (int i = 0; i < invString.Count; i++)
            {


                if (invString[i].Equals("Advanced Sword"))
                {
                    AdvancedSwordAmount += 1;
                    if (AdvancedSwordAmount > 1)
                    {
                        Console.WriteLine("Removed : " + invString[i]);
                        invString.Remove("Advanced Sword");
                        invString.Insert(i, " ");
                        Console.WriteLine("Size of array after removal : " + invString.Count);
                        Items.Weapons.AdvancedSword.advancedSwordAmount += 1;

                    }



                } // End of Advanced Sword





            } //End of for loop





        } // End of RemoveDuplicate


        public void convertToList()
        {

            //Convert all items back to a list array with Items

            //Remoces all items items in invetory
            inventory.Clear();

            foreach (String x in invString)
            {

                switch (x)
                {
                    case "Basic Sword":

                        inventory.Add(new Items.Weapons.BasicSword(basicSwordAmount));

                        break;

                    case "Advanced Sword":

                        inventory.Add(new Items.Weapons.AdvancedSword(AdvancedSwordAmount));

                        break;

                } //End of Switch statment



            } // End of EachFor loop

            invString.Clear();

            //Resets all variables
            AdvancedSwordAmount = 0;
            basicSwordAmount = 0;


        } // ENd of ConvertToList


        public void convertToString()
        {

            for (int i = 0; i < inventory.Count; i++)
            {
                invString.Add(inventory[i].Name);
            }
        } // End of Convert to string





    } // End of Class
}
