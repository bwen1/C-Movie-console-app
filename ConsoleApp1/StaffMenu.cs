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
        private MovieCollection moc;


        public StaffMenu(Program pr)
        {
            p = pr;
            mc = p.getMemberCollection();
            moc = p.getMovieCollection();

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
                return;
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
                    return;

                case 1:
                    moc.add(createMovie());
                    moc.displayMoviesBST();
                    moc.displayMovies();
                    break;

                case 2:
                    Console.WriteLine(removeMovie()); // TODO
                    break;

                case 3:
                    
                    mc.addNewMember(registerMember());
                    break;

                case 4:
                    findPhoneNumber();
                    break;

            }
            staffMenu();
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

        private Movie createMovie()
        {
            string title;
            string starring;
            string director;
            string genre = "Undefined";
            string classification = "Undefined";
            string duration;
            string releaseDate;
            string copiesAvailableString;
            string copiesAddedString;
            int copiesAvailable;
            int copiesAdded;
            Console.WriteLine("Enter the movie title: ");
            title = Console.ReadLine();

            if (moc.movieExists(title)) // Movie exists, add copies
            {
                copiesAddedString = assertNumber("Enter the number of copies you would like to add:");
                int.TryParse(copiesAddedString, out copiesAdded);
                moc.getMovieByTitle(title).addCopies(copiesAdded);
                Console.WriteLine(title + " now has " + moc.getMovieByTitle(title).getCopiesAvailable() + " copies available.");
                return null;
            }

            Console.WriteLine("Enter the starring actor(s): ");
            starring = Console.ReadLine();
            Console.WriteLine("Enter the director(s): ");
            director = Console.ReadLine();
            Console.WriteLine("\nSelect the genre: ");
            Console.WriteLine("1. Drama");
            Console.WriteLine("2. Adventure");
            Console.WriteLine("3. Family");
            Console.WriteLine("4. Action");
            Console.WriteLine("5. Sci-Fi");
            Console.WriteLine("6. Comedy");
            Console.WriteLine("7. Thriller");
            Console.WriteLine("8. Other");

            switch (genreInput())
            {
                case 1:
                    genre = "Drama";
                    break;

                case 2:
                    genre = "Adventure";
                    break;

                case 3:
                    genre = "Family";
                    break;

                case 4:
                    genre = "Action";
                    break;

                case 5:
                    genre = "Sci-Fi";
                    break;

                case 6:
                    genre = "Comedy";
                    break;

                case 7:
                    genre = "Thriller";
                    break;

                case 8:
                    genre = "Other";
                    break;

            }

            Console.WriteLine("\nSelect the classification: ");
            Console.WriteLine("1. General (G)");
            Console.WriteLine("2. Parental Guidance (PG)");
            Console.WriteLine("3. Mature (M15+)");
            Console.WriteLine("4. Mature Accompanied (MA15+)");

            switch (classificationInput())
            {
                case 1:
                    classification = "General (G)";
                    break;

                case 2:
                    classification = "Parental Guidance (PG)";
                    break;

                case 3:
                    classification = "Mature (M15+)";
                    break;

                case 4:
                    classification = "Mature Accompanied (MA15+)";
                    break;
            }

            duration = assertNumber("Enter the duration (minutes): ");
            releaseDate = assertNumber("Enter the release date (year): ");
            copiesAvailableString = assertNumber("Enter the number of copies available: ");
            int.TryParse(copiesAvailableString, out copiesAvailable);

            return new Movie(title, starring, director, duration, genre, classification, releaseDate, copiesAvailable);

            // Genre selection ensuring selection between 1 - 8
            int genreInput()
            {
                Console.WriteLine("Make Selection (1-8): ");
                string stringInput = Console.ReadLine();
                int intOutput;
                while (!((int.TryParse(stringInput, out intOutput)) && ((intOutput >=1) && (intOutput <= 8))))
                {
                    Console.Write("Error: Invalid Input\n");
                    Console.WriteLine("\n\nPlease make a selection (1-8):");
                    stringInput = Console.ReadLine();
                }
                return intOutput;
            }

            // Classification selection ensuring selection between 1 - 4
            int classificationInput()
            {
                Console.WriteLine("Make Selection (1-4): ");
                string stringInput = Console.ReadLine();
                int intOutput;
                while (!((int.TryParse(stringInput, out intOutput)) && ((intOutput >= 1) && (intOutput <= 4))))
                {
                    Console.Write("Error: Invalid Input\n");
                    Console.WriteLine("\n\nPlease make a selection (1-4):");
                    stringInput = Console.ReadLine();
                }
                return intOutput;
            }

            // Ensures string input is numeric
            string assertNumber(string prompt)
            {
                Console.WriteLine(prompt);

                string number = Console.ReadLine();
                // Ensures password is a 4 digit integer
                while (!(int.TryParse(number, out int numberInt)))
                {
                    Console.WriteLine("Please input a number");
                    Console.WriteLine(prompt);
                    number = Console.ReadLine();
                }

                return number;
            }
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
            if (mc.checkMemberExists(fullName))
            {
                Console.WriteLine("This member already exists.");
                return null;
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

        private string removeMovie() // TODO
        {
            string title;
            Console.WriteLine("Enter movie title: ");
            title = Console.ReadLine();
            bool removed = moc.removeMovie(title);
            if (removed == false)
            {
                return "Movie not found.";
            }
            removeMovieFromCustomers(title);
            return "Movie has been removed.";
        }

        private void removeMovieFromCustomers(string movie)
        {
            for (int i = 0; i < mc.getIMemberNum(); i++)
            {
                mc.members[i].returnMovie(movie);
            }
        }
    }
}
