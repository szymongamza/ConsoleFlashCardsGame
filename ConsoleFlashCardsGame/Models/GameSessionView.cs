using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFlashCardsGame.Models
{
    public class GameSessionView
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string StackName { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalAnswers { get; set; }
        public int TotalCards { get; set; }
    }
}
