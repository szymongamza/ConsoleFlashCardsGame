using ConsoleFlashCardsGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFlashCardsGame
{
    public class GameEngine
    {
        static bool saveStats;
        public static void  RunGame()
        {
            List<CardWithStackName> cards = SelectStack();
            if(cards.Count > 0)
            {
                SelectGameMode();
                GameSession session = new GameSession() { TotalCards = cards.Count, StackName = cards.First().StackName};
                Console.Clear();
                Console.WriteLine(@$"There is {session.TotalCards} cards to guess in {session.StackName} stack");
                Console.WriteLine($@"To start press enter");
                Console.ReadLine();
                Console.Clear();
                List<CardWithStackName> badAnswers = new List<CardWithStackName>();
                session.StartDateTime = DateTime.Now;
                int cardCounter = 1;
                session.CorrectAnswers = 0;
                session.TotalAnswers = 0;
                while (cards.Count > 0)
                {
                    var random = new Random();
                    Console.WriteLine($@"{cardCounter}/{session.TotalCards}");
                    int randomCardIndex = random.Next(cards.Count);
                    CardWithStackName card = cards[randomCardIndex];
                    cards.Remove(card);
                    Console.WriteLine("+---------------------------------------------+");
                    Console.WriteLine($@"   QUESTION: {card.Question}                 ");
                    Console.WriteLine("+---------------------------------------------+");
                    string answer = InputValidation.StringInput("Input your answer: (Type '0' to stop game)");
                    Console.Clear();
                    if(answer == "0")
                    {
                        break;
                    }
                    if(answer == card.Answer)
                    {
                        session.TotalAnswers++;
                        session.CorrectAnswers++;
                    }
                    else
                    {
                        session.TotalAnswers++;
                        badAnswers.Add(card);
                    }
                    cardCounter++;
                   
                }
                session.EndDateTime = DateTime.Now;
                Console.WriteLine("Your result:");
                Console.WriteLine($"Correct Answers: {session.CorrectAnswers}");
                Console.WriteLine($"Total Answers: {session.TotalAnswers}");
                Console.WriteLine($"Time spent: {session.EndDateTime - session.StartDateTime}");
                Console.WriteLine($"Total cards in stack: {session.TotalCards}");
                Console.WriteLine("Wrong Question - Answer:");
                foreach (CardWithStackName card in badAnswers)
                {
                    Console.WriteLine($"{card.Question} - {card.Answer}");
                }
            
                
            }
            if (saveStats)
            {
                //update session to db
            }
            return;
            
        }
        public static List<CardWithStackName> SelectStack()
        {
            //Show list of stacks
            Console.Clear();
            List<Stack> stacks = StacksController.GetStacks();
            //Select one stack
            if (stacks.Count == 0)
            {
                Console.WriteLine("There are no stacks yet. Create one first!");
                return null;
            }
            else
            {
                Stack stack = null;
                while (stack == null)
                {
                    string input = InputValidation.StringInput("Input name of the stack you want to play:");
                    stack = StacksController.GetStackByName(input, stacks);
                }
                List<CardWithStackName> cards = StacksController.GetStackWithCards(stack);
                Console.Clear();
                Console.WriteLine($@"Loaded {cards.Count()} cards");
                return cards;
            }
        }
        public static void SelectGameMode()
        {
            bool goBack = false;
            while (goBack == false)
            {
                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine($@"               GAMEMODE MENU                  ");
                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine("|    Type 0 to go back                        |");
                Console.WriteLine("|    Type 1 to Play with stats                |");
                Console.WriteLine("|    Type 2 to Play training                  |");
                Console.WriteLine("+---------------------------------------------+");

                int option = InputValidation.IntInput("Choose option from above menu.");
                switch (option)
                {
                    case 0:
                        Console.Clear();
                        goBack = true;
                        break;
                    case 1:
                        Console.Clear();
                        saveStats = true;
                        break;
                    case 2:
                        Console.Clear();
                        saveStats = false;
                        break;
                    default:
                        Console.Clear();
                        UserInterface.ShowOptionError();
                        break;
                }
            }
        }
    }
}
