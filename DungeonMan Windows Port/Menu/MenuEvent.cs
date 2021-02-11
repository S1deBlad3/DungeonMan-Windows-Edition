using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMan_Windows_Port.Menu
{
	public abstract class AMenuEvent : AMenu
	{
		

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


	} // End of class
}
