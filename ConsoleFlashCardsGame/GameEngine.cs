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
        public void startSession()
        {
            //Show list of stacks
            Console.Clear();
            List<Stack> stacks = StacksController.GetStacks();
            //Select one stack
            if (stacks.Count == 0)
            {
                Console.WriteLine("There are no stacks yet. Create one first!");
                return;
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
                Console.WriteLine("");
            }

            Console.Clear();

                //Show cards
                //Get stack with cards
                // Play game
        }
    }
}
