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
            mc = p.getMemberCollection();
            moc = p.getMovieCollection();

        }

        public void memberLogin() // Member login
        {
            Console.WriteLine("\nEnter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            if (mc.logIn(username, password) == null) // Logon failed
            {
                return;
            }

            loggedInUser = mc.logIn(username, password);
            memberMenu();
        }

        public void memberMenu() // Member menu
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
                    return;

                case 1:
                    printMovies(); 
                    break;

                case 2:
                    borrowMovie(); 
                    memberMenu();
                    break;

                case 3:
                    returnMovie();
                    memberMenu();
                    break;

                case 4:
                    listBorrowedMovies(); 
                    memberMenu();
                    break;

                case 5:
                    moc.topTenArray();
                    memberMenu();
                    break;

            }
        }

        private int memberSetUp() // Ensures member menu selections are within range
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

        private void printMovies() // Prints movies
        {
            moc.displayMovies();
            memberMenu();
        }

        private void borrowMovie() // Adds movie to member object array
        {
            string movieTitle;
            Console.WriteLine("Enter movie title:");
            movieTitle = Console.ReadLine();
            Movie movie = moc.getMovieByTitle(movieTitle);
            if (movie == null) // If movie exists
            {
                Console.WriteLine("Movie does not exist.");
                return;
            }
            if (loggedInUser.userHasMovie(movieTitle))
            {
                Console.WriteLine("You already have this movie.");
                return;
            }
            int copiesAvailable = movie.getCopiesAvailable();
            if (copiesAvailable <= 0) //  If movie has copies available
            {
                Console.WriteLine(movieTitle + " is unavailable.\n");
                return;
                
            }
            movie.addCopies(-1); // Reducing available copies by 1
            loggedInUser.borrowMovie(movieTitle); // Adding movie to member object
            movie.movieBorrowed(); // Keeping track of how many times movie is borrowed
            Console.WriteLine("You have borrowed " + movieTitle + ".");
            Console.Write(loggedInUser.listBorrowedMovies());
        }

        private void returnMovie() // Returns movie and removes it from member object array
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

        private void listBorrowedMovies() // List movies that member has borrowed
        {
            Console.WriteLine(loggedInUser.listBorrowedMovies());
        }
    }
}
