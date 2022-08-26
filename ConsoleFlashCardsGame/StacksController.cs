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
    public static class StacksController
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDBConnectionString"].ConnectionString;
        public static void CreateStack()
        {
            Stack stack = new();
            stack.Name = InputValidation.StringInput("Enter stack name:");

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
            Console.Clear();
            Console.WriteLine("Stack created Succesfully");
        }
        public static List<Stack> GetStacks()
        {
            List<Stack> stacks = new List<Stack>();
            SqlConnection connection = new SqlConnection(connectionString);
            using(connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"SELECT * FROM stack";

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        stacks.Add(new Stack { Id = reader.GetInt32(0), Name = reader.GetString(1) });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found!");
                }
                reader.Close();
            }
            return stacks;
        }
    }
}
