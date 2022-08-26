using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using QC = Microsoft.Data.SqlClient;

namespace ConsoleFlashCardsGame
{
    public static class DbManager
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDBConnectionString"].ConnectionString;

        public static void PrepareDB()
        {
            using (var connection = new QC.SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = 
                        $@" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'stack')
                            CREATE TABLE stack (
                                Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
                                Name varchar(100) NOT NULL UNIQUE
                            );
                        ";
                    command.ExecuteNonQuery();

                    command.CommandText =
                        $@" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'card')
                            CREATE TABLE card (
                                Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
                                Question varchar(100) NOT NULL,
                                Answer varchar(100) NOT NULL,
                                StackId int NOT NULL FOREIGN KEY REFERENCES stacks(Id) ON DELETE CASCADE ON UPDATE CASCADE
                            );
                        ";
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            Console.WriteLine("Database ready for action.");
        }

        public static void TestDBConnection()
        {
            using (var connection = new QC.SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected successfully.");
                connection.Close();
            }
        }
    }
}
