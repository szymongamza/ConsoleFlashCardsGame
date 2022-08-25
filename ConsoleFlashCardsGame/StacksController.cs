using ConsoleFlashCardsGame.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFlashCardsGame
{
    public class StacksController
    {
        InputValidation inputValidation = new InputValidation();
        public string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDBConnectionString"].ConnectionString;
        public void CreateStack()
        {
            Stack stack = new();
            inputValidation.StringInput("Enter stack name:");

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"INSERT INTO stack (Name) VALUES ('{stack.Name}')";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
