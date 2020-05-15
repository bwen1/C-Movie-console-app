using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Member
    {
        private string name;
        private string address;
        private string phoneNumber;
        private string password;
        private string userName;

        private const int maxMoviesBorrowed = 10;
        public string[] movies;
        private int iMovieNum;

        public Member(string firstName, string lastName, string address, string phoneNumber, string password)
        {
            this.name = firstName + " " + lastName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.userName = lastName + firstName;
            clearMovie();


        }
        // ACCESSORY FUNCTIONS
        public string getName()
        {
            return name;
        }

        public string getUserName()
        {
            return userName;
        }

        public string getPassword()
        {
            return password;
        }

        public string getPhoneNumber()
        {
            return phoneNumber;
        }
        // ACCESSORY FUNCTIONS

        private void clearMovie() // Clears movies array
        {
            movies = new string[maxMoviesBorrowed];
            for (int i = 0; i < maxMoviesBorrowed; i++)
            {
                movies[i] = "";
            }
            iMovieNum = 0;
        }

        public void borrowMovie(string movieTitle) // Borrows movie
        {
            if (iMovieNum == maxMoviesBorrowed)
            {
                Console.WriteLine("You have reached the maximum movies borrowed.\n"); // Reached max limit
                return;
            }
                
            
            for (int i = 0; i < maxMoviesBorrowed; i++)
            {
                if (movies[i].Equals(""))
                {
                    movies[i] = movieTitle;
                    iMovieNum++;
                    return;
                }
            }
                
           
        }

        public bool userHasMovie(string movieTitle) // Return true if member has movie
        {
            for (int i = 0; i < maxMoviesBorrowed; i++)
            {
                if (movieTitle.Equals(movies[i]))
                {
                    return true; // Movie found
                }
            }

            return false; // Movie does not exist
        }

        public void returnMovie(string movieTitle) // Returns the movie
        {
            for (int i = 0; i < maxMoviesBorrowed; i++)
            {
                if (movieTitle.Equals(movies[i]))
                {
                    movies[i] = "" ; // Movie removed
                    iMovieNum--;
                    Console.WriteLine("Movie DVD returned.\n");
                    return;
                }
            }
        }

        public string listBorrowedMovies() // Returns string of borrowed movies
        {
            string moviesBorrowed = "";
            if (iMovieNum == 0)
            {
                return "You have no borrowed movies.";
            }

            for (int i = 0; i < maxMoviesBorrowed; i++)
            {
                if (movies[i] != "")
                {
                    if (moviesBorrowed.Equals("")) // If first movie in list, don't add comma
                    {
                        moviesBorrowed = moviesBorrowed + movies[i];
                    }
                    else
                    {
                        moviesBorrowed = moviesBorrowed + ", " + movies[i];
                    }
                } 
            }
            return "You are borrowing: \n" + moviesBorrowed;
        }
    }
}
