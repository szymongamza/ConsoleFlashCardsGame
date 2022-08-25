using System;


namespace ConsoleFlashCardsGame
{
	public class Program
	{
		static public void Main()
        {
			DbManager dbManager = new DbManager();
			dbManager.TestDBConnection();
			dbManager.PrepareDB();
			UserInterface userInterface = new UserInterface();
			userInterface.MainMenuLoop();

		}
	}
}
