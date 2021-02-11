using DungeonMan_Windows_Port.Entity.Player;
using DungeonMan_Windows_Port.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Text;
using DungeonMan_Windows_Port.Menu;

namespace DungeonMan_Windows_Port.World
{
	public class Shop : Menu.AMenu
	{


		public List<Items.Items> shopInv = new List<Items.Items>();

		//Items And Weapons List
		private Items.Items basicSword = new BasicSword();
		private Items.Items advancedSword = new AdvancedSword();




		//Menu
		String[] menuS = { "Buy", "Sell", "Exit" };

		//EventHandler For Menu



		public Player player;

		public bool inMenu;

		public Shop(Player player)
		{
			this.player = player;


			shopInv.Add(basicSword);
			shopInv.Add(advancedSword);

			inMenu = true;

			mainLoop();

		}



		public void mainLoop()
		{

			ContextMenu(menuS, 10);
			selected = 0;

			while (inMenu)
			{

				//player.debugScreen();






				Console.WriteLine("Buy or sell or Exit");

				String decision = Console.ReadLine();



				switch (decision)
				{



					case "Buy":
					case "buy":

						buyLoop();

						break;


					case "Sell":
					case "sell":

						sellLoop();

						break;

					case "exit":

						new OverWorld(player);

						break;



				}

			}
		}



		public void buyLoop()
		{

			bool canBuy;
			int amount;


			Console.WriteLine("What would you like to buy");

			foreach (var e in shopInv)
			{
				Console.WriteLine("{0} cost {1} gold and has attack worth {2}", e.Name, e.getCost(), e.getDamage());
			}


			String decision = Console.ReadLine();

			switch (decision)
			{

				case "Basic Sword":
				case "basic sword":

					Console.WriteLine("How many?");
					amount = Convert.ToInt32(Console.ReadLine());

					canBuy = CheckIfCanBuy(basicSword, amount);

					if (canBuy)
					{
						player.addItem(basicSword, amount);
					}
					else
					{

						mainLoop();
						return;
					}


					break;
				case "Advanced Sword":
				case "advanced sword":

					Console.WriteLine("How many?");
					amount = Convert.ToInt32(Console.ReadLine());

					canBuy = CheckIfCanBuy(advancedSword, amount);

					if (canBuy)
					{
						player.addItem(advancedSword, amount);
					}
					else
					{

						mainLoop();
						return;
					}

					break;




			}


		} //End of BuyLoop





		public void sellLoop()
		{

		}//End Of sellLoop




		public bool CheckIfCanBuy(Items.Items item, int amount)
		{

			if (player.money >= (item.cost * amount))
			{
				player.money -= item.cost * amount;

				Console.WriteLine("It cost {0}", player.money);


				return true;
			}
			else
			{

				Console.WriteLine("You cant buy this");
				return false;
			}




		} // End of CheckIFCanBuy


		public virtual void ContextMenu(String[] menuItems, int SizeOfRow)
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

			Console.Clear();

			MainEntry.space();


			Console.WriteLine("What would you like to do?");

			for (int i = 0; i < SizeOfRow; i++)
			{
				Console.Write(outLine);
			}

			Console.WriteLine();

			//Console.WriteLine("#############");

			for (int i = 0; i < menuList.Length; i++)
			{
				Console.Write(outLine + space + space);

				//Implement own EventHandler

				if (i == 0 && selected == 0)
				{
					Console.Write(cursor);

				}
				if (i == 1 && selected == 1)
				{
					Console.Write(cursor);
				}
				if (i == 2 && selected == 2)
				{
					Console.Write(cursor);
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
					buyLoop();
					break;
				case 1:
					sellLoop();
					break;
				case 2:
					new OverWorld(player);
					break;
			}


		}

		//To here



	}//End of class
}
