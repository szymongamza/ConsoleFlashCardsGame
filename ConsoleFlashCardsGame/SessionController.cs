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
    public static class SessionController
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDBConnectionString"].ConnectionString;
        static SqlConnection connection = new SqlConnection(connectionString);

        public static void UploadSession(GameSession gameSession)
        {
            using (connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"INSERT INTO session (StartDateTime, EndDateTime, StackId, StackName, CorrectAnswers, TotalAnswers, TotalCards) 
                    VALUES ('{gameSession.StartDateTime}','{gameSession.EndDateTime}','{gameSession.StackO.Id}','{gameSession.StackO.Name}','{gameSession.CorrectAnswers}',
                    '{gameSession.TotalAnswers}','{gameSession.TotalCards}')";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void GetSessions()
        {
            List<GameSessionView> sessions = new List<GameSessionView>();
            using (connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $@"SELECT * FROM session;";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sessions.Add(new GameSessionView
                        {
                            StartDateTime = reader.GetDateTime(1),
                            EndDateTime = reader.GetDateTime(2),
                            StackName = reader.GetString(4),
                            CorrectAnswers = reader.GetInt32(5),
                            TotalAnswers = reader.GetInt32(6),
                            TotalCards = reader.GetInt32(7)
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found!");
                }
                reader.Close();
            }
            TableVisualizer.ShowTable(sessions, null);
        }
    }
}
