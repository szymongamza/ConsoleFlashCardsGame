using System;


namespace ConsoleFlashCardsGame
{
	public class Program
	{
		static public void Main()
        {
			DBManager dbManager = new DBManager();
			dbManager.TestDBConnection();
			dbManager.PrepareDB();

		}
	}
}
