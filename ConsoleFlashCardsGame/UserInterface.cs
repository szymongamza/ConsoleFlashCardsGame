using ConsoleFlashCardsGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFlashCardsGame
{
    public static class UserInterface
    {
        public static void MainMenuLoop()
        {
            Console.Clear();
            bool quitApp = false;
            while (quitApp == false)
            {
                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine("|                   MAIN MENU                 |");
                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine("|    Type 0 to quit app                       |");
                Console.WriteLine("|    Type 1 to Configure stacks               |");
                Console.WriteLine("|    Type 2 to Play FlashCards                |");
                Console.WriteLine("+---------------------------------------------+");

                int option = InputValidation.IntInput("Choose option from above menu.");
                switch (option)
                {
                    case 0:
                        quitApp = true;
                        break;
                    case 1:
                        Console.Clear();
                        ConfigureStacksMenu();
                        break;
                    default:
                        Console.Clear();
                        ShowOptionError();
                        break;
                }

            }
        }
        public static void ConfigureStacksMenu()
        {
            bool goBack = false;
            while (goBack == false)
            {
                Console.Clear();
                List<Stack> stacks = StacksController.GetStacks();

                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine("|           CONFIGURE STACKS MENU             |");
                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine("|    Type 0 to go back                        |");
                Console.WriteLine("|    Type 1 to Add stack                      |");
                Console.WriteLine("|    Type 2 to Edit stack                     |");
                Console.WriteLine("|    Type 3 to Delete stack                   |");
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
                        StacksController.CreateStack();
                        break;
                    case 2:
                        if(stacks.Count == 0)
                        {
                            Console.WriteLine("There are no stacks yet. Create one first!");
                            break;
                        }
                        else
                        {
                            Stack stack = null;
                            while (stack == null)
                            {
                                string input = InputValidation.StringInput("Input name of the stack to edit it:");
                                stack = StacksController.GetStackByName(input, stacks);
                            }
                            Console.Clear();
                            //Show cards
                            EditStackMenu(stack);
                            break;
                        }
                        
                    case 3:
                        if (stacks.Count == 0)
                        {
                            Console.WriteLine("There are no stacks yet. Create one first!");
                            break;
                        }
                        else
                        {
                            Stack stack = null;
                            while (stack == null)
                            {
                                string input = InputValidation.StringInput("Input name of the stack to edit it:");
                                stack = StacksController.GetStackByName(input, stacks);
                            }
                            Console.Clear();
                            StacksController.DeleteStack(stack);
                            break;
                        }
                    default:
                        Console.Clear();
                        ShowOptionError();
                        break;
                }
            }
        }
        public static void EditStackMenu(Stack stack)
        {
            bool goBack = false;
            while (goBack == false)
            {
                Console.Clear();
                List<Card> cards = CardsController.GetCardsByStack(stack);
                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine($@"           EDIT '{stack.Name}' STACK MENU                ");
                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine("|    Type 0 to go back                        |");
                Console.WriteLine("|    Type 1 to Change name of stack           |");
                Console.WriteLine("|    Type 2 to Add card to stack              |");
                Console.WriteLine("|    Type 3 to Edit card from stack           |");
                Console.WriteLine("|    Type 4 to Delete card from stack         |");
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
                        StacksController.UpdateStackName(stack);
                        break;
                    case 2:
                        Console.Clear();
                        CardsController.CreateCard(stack);
                        break;
                    case 3:
                        if (cards.Count == 0)
                        {
                            Console.WriteLine("There are no cards yet. Create one first!");
                            break;
                        }
                        else
                        {
                            Card card = null;
                            while (card == null)
                            {
                                int input = InputValidation.IntInput("Input id of the card to edit it:");
                                card = CardsController.GetCardById(input, cards);
                            }
                            Console.Clear();
                            CardsController.UpdateCard(card);
                            break;
                        }
                        break;
                    case 4:
                        if (cards.Count == 0)
                        {
                            Console.WriteLine("There are no cards yet. Create one first!");
                            break;
                        }
                        else
                        {
                            Card card = null;
                            while (card == null)
                            {
                                int input = InputValidation.IntInput("Input id of the card to edit it:");
                                card = CardsController.GetCardById(input, cards);
                            }
                            Console.Clear();
                            CardsController.DeleteCard(card);
                            break;
                        }
                    default:
                        Console.Clear();
                        ShowOptionError();
                        break;
                }
            }
        }
        public static void ShowOptionError()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("|       Choose option from menu!        |");
            Console.WriteLine("-----------------------------------------");
        }
    }
}
