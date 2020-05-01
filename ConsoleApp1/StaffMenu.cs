using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StaffMenu
    {
        // Staff login details
        private const string staffUsername = "staff";
        private const string staffPassword = "today123";
        private Program p;
        private MemberCollection mc;

        public StaffMenu(Program pr)
        {
            p = pr;
            mc = new MemberCollection();
        }


        public void staffLogin()
        {
            Console.WriteLine("\nEnter Username:");
            string stringUsername = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string stringPassword = Console.ReadLine();

            if ((stringUsername == staffUsername) && (stringPassword == staffPassword))
            {
                staffMenu();

            }

            else
            {
                Console.WriteLine("\nYour logon information was incorrect.");
                p.mainMenu();
            }

        }

        private void staffMenu()
        {
            Console.WriteLine("\n==========Staff Menu==========");
            Console.WriteLine(" 1. Add a new movie DVD");
            Console.WriteLine(" 2. Remove a movie DVD");
            Console.WriteLine(" 3. Register a new Member");
            Console.WriteLine(" 4. Find a registered member's phone number");
            Console.WriteLine(" 0. Return to main menu");
            Console.WriteLine("==============================");

            switch (staffSetUp())
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
                    
                    mc.addNewMember(registerMember());
                    break;

                case 4:
                    findPhoneNumber();
                    break;

            }
        }

        private int staffSetUp()
        {
            Console.WriteLine("\n\nPlease make a selection (1-4, or 0 to return to main menu):");
            string stringSelection = Console.ReadLine();
            int intSelection;

            // If user input is not in specified range or not an int, user will be prompted to re-input 
            while (!int.TryParse(stringSelection, out intSelection) || !((intSelection <= 4) && (intSelection >= 0)))
            {
                Console.Write("Error: Invalid Input\n");
                Console.WriteLine("\n\nPlease make a selection (1-4, or 0 to exit):");
                stringSelection = Console.ReadLine();

            }
            return intSelection;

        }

        private Member registerMember()
        {
            string firstName;
            string lastName;
            string address;
            string phoneNumber;
            string password;
            string fullName;
            Console.WriteLine("Enter member's first name:");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter member's last name:");
            lastName = Console.ReadLine();
            fullName = firstName + " " + lastName;
            foreach (Member person in mc.members)
            {
                if (fullName == person.name)
                {
                    Console.WriteLine("\n\nMember already registered.");
                    return null;
                }

            }
            Console.WriteLine("Enter member's address:");
            address = Console.ReadLine();
            Console.WriteLine("Enter member's phone number:");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter member's password (4 digits):");
            password = Console.ReadLine();

            // Ensures password is a 4 digit integer
            while (!((int.TryParse(password, out int pin)) && password.Length == 4))
            {
                Console.WriteLine("Enter member's password (4 digits):");
                password = Console.ReadLine();
            }

            return new Member(firstName, lastName, address, phoneNumber, password);

        }

        private void findPhoneNumber()
        {
            string firstName;
            string lastName;
            string fullName;
            string phoneNumber;
            Console.WriteLine("Enter member's first name:");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter member's last name:");
            lastName = Console.ReadLine();

            fullName = firstName + " " + lastName;

            phoneNumber = mc.findPhoneNumber(fullName);

            if (phoneNumber != null)
            {
                Console.WriteLine(fullName + "'s phone number is: " + phoneNumber);
            }
            else Console.WriteLine("Member not found");

        }
    }
}
