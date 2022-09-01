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
            using (connection)
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
            TableVisualizer.ShowTable(stacks, null);
            return stacks;
        }
        public static void DeleteStack(Stack stack)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"DELETE FROM stack WHERE Id = ('{stack.Id}')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            Console.WriteLine("Stack successfully deleted.");
        }
        public static void UpdateStackName(Stack stack)
        {
            stack.Name = InputValidation.StringInput("Enter new stack name:");
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"UPDATE stack SET Name = ('{stack.Name}') WHERE Id = ('{stack.Id}')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            Console.WriteLine("Stack successfully updated.");
        }
        public static Stack GetStackByName(string input, List<Stack> stacks)
        {
            foreach(Stack stack in stacks)
            {
                if(stack.Name == input)
                {
                    return stack;
                }
            }
            return null;
        }
        public static List<CardWithStackName> GetStackWithCards(Stack stack)
        {
            List<CardWithStackName> cards = new List<CardWithStackName>();
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"SELECT * FROM card WHERE StackId = ('{stack.Id}')";

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //TODO
                        cards.Add(new CardWithStackName { Id = reader.GetInt32(0), Question = reader.GetString(1), Answer = reader.GetString(2), StackName=stack.Name });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found!");
                }
                reader.Close();
            }
            //DTO
            TableVisualizer.ShowTable(cards, null);
            return cards;
        }
    }
}
