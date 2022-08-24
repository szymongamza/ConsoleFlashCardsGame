using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using QC = Microsoft.Data.SqlClient;

namespace ConsoleFlashCardsGame
{
    public class DBManager
    {
        readonly String _connectionString;

        public DBManager()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDBConnectionString"].ConnectionString;
        }
        public void PrepareDB()
        {
            using (var connection = new QC.SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = 
                        $@" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'stacks')
                            CREATE TABLE stacks (
                                Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
                                Name varchar(100) NOT NULL UNIQUE
                            );
                        ";
                    command.ExecuteNonQuery();

                    command.CommandText =
                        $@" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'cards')
                            CREATE TABLE cards (
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

        public void TestDBConnection()
        {
            using (var connection = new QC.SqlConnection(_connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected successfully.");
                connection.Close();
            }
        }
    }
}
