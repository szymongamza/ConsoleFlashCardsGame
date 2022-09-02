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

        public static void UploadSession(GameSession gameSession)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = 
                    $@"INSERT INTO session"
            }
        }
    }
}
