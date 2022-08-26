using System;


namespace ConsoleFlashCardsGame
{
	public class Program
	{
		static public void Main()
        {
			DbManager.TestDBConnection();
			DbManager.PrepareDB();
			UserInterface.MainMenuLoop();

		}
	}
}
