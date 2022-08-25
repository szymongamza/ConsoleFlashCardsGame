using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFlashCardsGame
{
    public class UserInterface
    {
        InputManager inputManager = new InputManager();
        public UserInterface()
        {
            MainMenuLoop();
        }

        public void MainMenuLoop()
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

                int option = validationInput.IntInput("Choose option from above menu.");
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
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("|       Choose option from menu!        |");
                        Console.WriteLine("-----------------------------------------");
                        break;
                }

            }
        }
        public void ConfigureStacksMenu()
        {
            
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|           CONFIGURE STACKS MENU             |");
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|    Type 0 to go back                        |");
            Console.WriteLine("|    Type 1 to Edit stack                     |");
            Console.WriteLine("|    Type 2 to Delete stack                   |");
            Console.WriteLine("+---------------------------------------------+");
        }
    }
}
