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
        private void clearMovie()
        {
            movies = new string[maxMoviesBorrowed];
            for (int i = 0; i < maxMoviesBorrowed; i++)
            {
                movies[i] = "";
            }
            iMovieNum = 0;
        }
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

        public void borrowMovie(string movieTitle)
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
                    movies[iMovieNum] = movieTitle;
                    iMovieNum++;
                    return;
                }
            }
                
           
        }

        public bool userHasMovie(string movieTitle)
        {
            for (int i = 0; i < iMovieNum; i++)
            {
                if (movieTitle.Equals(movies[i]))
                {
                    return true; // Movie found
                }
            }

            return false; // Movie does not exist
        }

        public void returnMovie(string movieTitle)
        {
            for (int i = 0; i < iMovieNum; i++)
            {
                if (movieTitle.Equals(movies[i]))
                {
                    movies[iMovieNum] = "" ; // Movie removed
                    iMovieNum--;
                    Console.WriteLine("Movie DVD returned.\n");
                    return;
                }
            }
        }

        public string listBorrowedMovies()
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
