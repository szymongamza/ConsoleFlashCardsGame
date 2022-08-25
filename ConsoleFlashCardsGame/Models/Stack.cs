using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFlashCardsGame.Models
{
    public class Stack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Card[] Cards { get; set; }

    }
}
