using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MemberMenu
    {
        private Program p;
        private MemberCollection mc;
        private MovieCollection moc;
        private Member loggedInUser;
        
        public MemberMenu (Program pr)
        {
            p = pr;
            mc = new MemberCollection();
            moc = new MovieCollection();

        }
        public void memberLogin() // NOT WORKING
        {
            Console.WriteLine("\nEnter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            if (mc.logIn(username, password) == null)
            {
                Console.WriteLine("\nYour logon information was incorrect.");
                p.mainMenu();
            }

            loggedInUser = mc.logIn(username, password);
            memberMenu();
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
                    printMovies(); // TODO
                    break;

                case 2:
                    borrowMovie(); // Not tested
                    break;

                case 3:
                    returnMovie(); // Not tested
                    break;

                case 4:
                    listBorrowedMovies(); // Not tested
                    break;

                case 5:
                    //memberLogin();
                    break;

            }
        }

        private int memberSetUp()
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

        private string printMovies()
        {
            // BST traversal
            return null;
        }

        private void borrowMovie()
        {
            string movieTitle;
            Console.WriteLine("Enter movie title:");
            movieTitle = Console.ReadLine();

            if ((moc.movieExists(movieTitle)) && (moc.getMovieByTitle(movieTitle).getCopiesAvailable() > 0)) // If movie exists and has copies available
            {
                moc.getMovieByTitle(movieTitle).addCopies(-1); // Reducing available copies by 1
                loggedInUser.borrowMovie(movieTitle); // Adding movie to member object
                moc.getMovieByTitle(movieTitle).movieBorrowed(); // Keeping track of how many times movie is borrowed
            }
            else
            {
                Console.WriteLine(movieTitle + " is unavailable.\n");
            }
        }

        private void returnMovie()
        {
            string movieTitle;
            Console.WriteLine("Enter movie title:");
            movieTitle = Console.ReadLine();
            

            if ((moc.movieExists(movieTitle)) && loggedInUser.userHasMovie(movieTitle)) // If movie exists and has copies available
            {
                moc.getMovieByTitle(movieTitle).addCopies(1);
                loggedInUser.returnMovie(movieTitle);
            }
            else
            {
                Console.WriteLine(movieTitle + " not found.\n");
            }
        }

        private string listBorrowedMovies()
        {
            return loggedInUser.listBorrowedMovies();
        }
    }
}
