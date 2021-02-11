using DungeonMan_Windows_Port.Entity.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMan_Windows_Port.World
{
	public class BattleMap
	{

		private Player player;
		private Random random;
		private int numberOfEnemies;
		private int MaxNumOfEnemies;
		private int MinNumOfEnemies;



		//Menu Variables
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
			"(a)ttack",
			  "(d)efend",
			  "(i)tems",
				"(r)un",
			   "(e)xit"};


		//List of enemies
		private List<Entity.Entity> arrayOFEnemies = new List<Entity.Entity>();


		public List<Entity.Entity> NumberOnBattleField = new List<Entity.Entity>();

		//public Hashtable enemies;

		// public Entity.Enemy.StandardEnemy[] enemies;


		//Clears the console and sets the instance of player to player from overworld (slow, implement by ref instead)

		public BattleMap(Player player)
		{
			this.player = player;

			firstLaunch = true;

			Console.Clear();


			//Gets a random number based on area (currently 1-3 enemeis can show up)
			numberOfEnemies = Encounter();




			//enemies = new Entity.Enemy.StandardEnemy[numberOfEnemies];


			//Makes random enemies //Add more enemies

			for (int i = 0; i < numberOfEnemies; i++)
			{


				switch (RandomOrder())
				{

					case 1:
						NumberOnBattleField.Add(new Entity.Enemy.StandardEnemy(10, 10, 10));

						Console.WriteLine("Standard Enemy");


						break;
					case 2:
						NumberOnBattleField.Add(new Entity.Enemy.HardEnemy(15, 15, 0));

						Console.WriteLine("Advanced Enemy");

						break;



				}



				//Console.WriteLine(i);
			}
			//Just writes info about monsters
			foreach (var m in NumberOnBattleField)
			{

				Console.WriteLine("You have meet {0}", m.getName());
				// Console.WriteLine(m.getHealth());



			}
			//Starts the loop
			CombatLoop();

		}


		//Uses an array to create a random number between the available mobs
		private int numOfEnemeis()
		{
			//Add numbers of enemeies
			arrayOFEnemies.Add(new Entity.Enemy.StandardEnemy(20, 5, 0));
			arrayOFEnemies.Add(new Entity.Enemy.HardEnemy(30, 10, 0));


			return arrayOFEnemies.Count;
		}

		//Creates a random number based on context (how many enemeis that can show up)
		public int Encounter()
		{


			return new Random().Next(1, 3);
		}

		//Gets the number from array created in numOfEnemies
		public int RandomOrder()
		{
			return new Random().Next(1, numOfEnemeis());
		}

		public void CombatLoop()
		{

			//As long as the player is alive the loop continue
			while (player.getHealth() > 0)
			{

				if (firstLaunch)
				{
					selected = 0;
					ContextMenu();
					firstLaunch = false;
				}



				ContextMenu();







			}




		}


		public void attackLoop()
		{

			//As long as there is more than 0 enemeis the fight will continue

			while (NumberOnBattleField.Count > 0)
			{


				//Starts with the player attacking first
				player.fight(player.getAttack(), NumberOnBattleField[new Random().Next(0, NumberOnBattleField.Count)]);

				//Goes through all of the enemeis in numberonbattlefiled list
				foreach (var e in NumberOnBattleField)
				{
					e.fight(e.getAttack(), player);
					//Checks if it is dead
					if (e.getHealth() <= 0)
					{
						//Finds which unit died
						var dead = e.getName();
						Console.ForegroundColor = ConsoleColor.Blue;
						MainEntry.space();
						Console.WriteLine(dead + " Is dead");
						//Console.WriteLine(En.Count);
						Console.ResetColor();


						//Money and XP drop algorhtim
						double money = new Random().Next(0, e.gold) / 2 * 0.5;
						player.money += Convert.ToInt32(money);

						double xp = new Random().Next(0, e.xp) / 2 * 0.3;
						player.xp += Convert.ToInt32(xp);


						//Removes Enemy from list of Enemies
						NumberOnBattleField.Remove(e);
						//Console.WriteLine(En.Count);

						MainEntry.space();

						break;

					}




					// Console.WriteLine(e.getName() + " " + enemies.Length);
					// Console.WriteLine("{0} has {1} health", e.getName(), e.getHealth());
					// Console.WriteLine("You have {0} health left", player.getHealth());
				}


				if (NumberOnBattleField.Count == 0)
				{
					NumberOnBattleField = null;
					new OverWorld(player);
				}

				CombatLoop();

			}


		} //End of attack loop



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
			showEnemy();
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
					attackLoop();
					break;
				case 1:
					//Defense
					break;
				case 2:
					player.Inventory();
					break;
				case 3:
					new OverWorld(player);
					break;
				case 4:
					Environment.Exit(0);
					break;
			}






		}


		private void showEnemy()
		{
			Console.WriteLine("##############################");
			foreach (var x in NumberOnBattleField)
			{
				Console.Write(outLine + space);
				Console.Write(x.getName() + " " + "Health = " + x.health + space);


				size = x.name.Length;

				for (int y = size; y < 15; y++)
				{
					Console.Write(outLine);
				}
				Console.WriteLine();

				size = 0;
			}
		}

	}
}
