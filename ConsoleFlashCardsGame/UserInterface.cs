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
                        Console.WriteLine("SHOW TABLE HERE");
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
                        Console.Clear();
                        //Show cards
                        EditStackMenu();
                        break;
                    case 3:
                        Console.Clear();
                        //Delete Stack
                        break;
                    default:
                        Console.Clear();
                        ShowOptionError();
                        break;
                }
            }
        }
        public static void EditStackMenu()
        {
            bool goBack = false;
            while (goBack == false)
            {

                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine("|              EDIT STACK MENU                |");
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
                        //ChangeNameOfStack();
                        break;
                    case 2:
                        Console.Clear();
                        //AddCardToStack();
                        break;
                    case 3:
                        Console.Clear();
                        //EditCard();
                        break;
                    case 4:
                        Console.Clear();
                        //DeleteCard();
                        break;
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
