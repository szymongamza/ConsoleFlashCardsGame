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
    public class CardsController
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDBConnectionString"].ConnectionString;
        public static void CreateCard(Stack stack)
        {
            Card card = new();
            card.Question = InputValidation.StringInput("Enter card question:");
            card.Answer = InputValidation.StringInput("Enter card answer:");

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"INSERT INTO card (Question, Answer, StackId) VALUES ('{card.Question}','{card.Answer}','{stack.Id}')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            Console.Clear();
            Console.WriteLine("Card created Succesfully");
        }
        public static List<Card> GetCardsByStack(Stack stack)
        {
            List<Card> cards = new List<Card>();
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
                        cards.Add(new Card { Id = reader.GetInt32(0), Question = reader.GetString(1), Answer = reader.GetString(2) });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found!");
                }
                reader.Close();
            }
            TableVisualizer.ShowTable(cards, null);
            return cards;
        }
        public static void DeleteCard(Card card)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"DELETE FROM card WHERE Id = ('{card.Id}')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            Console.WriteLine("Card successfully deleted.");
        }
        public static Card GetCardById(int id, List<Card> cards)
        {
            foreach (Card card in cards)
            {
                if (card.Id == id)
                {
                    return card;
                }
            }
            return null;
        }
        public static void UpdateCard(Card card)
        {
            Console.WriteLine($@"Actual Question: {card.Question}");
            Console.WriteLine("New card question: (Leave empty to leave actual)");
            string input = Console.ReadLine();
            if (input.Length > 0)
            {
                card.Question = input;
            }
            Console.WriteLine($@"Actual Answer: {card.Answer}");
            Console.WriteLine("New card answer: (Leave empty to leave actual)");
            input = Console.ReadLine();
            if (input.Length > 0)
            {
                card.Answer = input;
            }

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"UPDATE card SET Question = ('{card.Question}'), Answer = ('{card.Answer}') WHERE Id = ('{card.Id}')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            Console.WriteLine("Stack successfully updated.");
        }
    }
}
