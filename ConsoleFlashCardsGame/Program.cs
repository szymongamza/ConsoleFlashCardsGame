using System;
using QC = Microsoft.Data.SqlClient;

namespace ConsoleFlashCardsGame
{
	public class Program
	{
		static public void Main()
		{
			using (var connection = new QC.SqlConnection(
				"Server=(LocalDb)\\FlashCardsDB;" +
				"Database=FlashCardsDb;"
				))
			{
				connection.Open();
				Console.WriteLine("Connected successfully.");

				Console.WriteLine("Press any key to finish...");
				Console.ReadKey(true);
			}
		}
	}
}
/**** Actual output:  
Connected successfully.  
Press any key to finish...  
****/  