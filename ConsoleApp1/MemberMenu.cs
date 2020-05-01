using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MemberMenu
    {
        // For development purposes
        private const string memberUsername = "member";
        private const string memberPassword = "today123";
        private Program p;
        
        public MemberMenu (Program pr)
        {
            p = pr;
        }
        public void memberLogin()
        {
            Console.WriteLine("\nEnter Username:");
            string stringUsername = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string stringPassword = Console.ReadLine();

            if ((stringUsername == memberUsername) && (stringPassword == memberPassword))
            {
                memberMenu();

            }

            else
            {
                Console.WriteLine("\nYour logon information was incorrect.");
                p.mainMenu();
            }

        }

        public void memberMenu()
        {
            Console.WriteLine("\n=========Member Menu=========");
            Console.WriteLine(" 1. Display all movies");
            Console.WriteLine(" 2. Borrow a movie DVD");
            Console.WriteLine(" 3. Return a movie DVD");
            Console.WriteLine(" 4. List current borrowed movie DVDs");
            Console.WriteLine(" 5. Display top 10 most popular movies");
            Console.WriteLine(" 0. Return to main menu");
            Console.WriteLine("==============================");

            switch (memberSetUp())
            {
                case 0:
                    p.mainMenu();
                    break;

                case 1:
                    //staffLogin();
                    break;

                case 2:
                    //memberLogin();
                    break;

                case 3:
                    //memberLogin();
                    break;

                case 4:
                    //memberLogin();
                    break;

                case 5:
                    //memberLogin();
                    break;

            }
        }

        static int memberSetUp()
        {
            Console.WriteLine("\n\nPlease make a selection (1-5, or 0 to return to main menu):");
            string stringSelection = Console.ReadLine();
            int intSelection;

            // If user input is not in specified range or not an int, user will be prompted to re-input 
            while (!int.TryParse(stringSelection, out intSelection) || !((intSelection <= 5) && (intSelection >= 0)))
            {
                Console.Write("Error: Invalid Input\n");
                Console.WriteLine("\n\nPlease make a selection (1-5, or 0 to exit):");
                stringSelection = Console.ReadLine();

            }
            return intSelection;
        }
    }
}
