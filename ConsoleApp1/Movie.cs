using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Movie
    {
        private string title;
        private string starring;
        private string director;
        private string duration;
        private string genre;
        private string classification;
        private string releaseDate;
        private int copiesAvailable;
        private int timesBorrowed = 0;

        
        public Movie(string title, string starring, string director, string duration, string genre, string classification, string releaseDate, int copiesAvailable)
        {
            this.title = title;
            this.starring = starring;
            this.director = director;
            this.duration = duration;
            this.genre = genre;
            this.classification = classification;
            this.releaseDate = releaseDate;
            this.copiesAvailable = copiesAvailable;

        }

        public string getTitle()
        {
            return title;
        }

        public int getCopiesAvailable()
        {
            return copiesAvailable;
        }

        public int getTimesBorrowed()
        {
            return timesBorrowed;
        }

        public string getStarring()
        {
            return starring;
        }

        public string getDirector()
        {
            return director;
        }

        public string getDuration()
        {
            return duration;
        }

        public string getGenre()
        {
            return genre;
        }

        public string getClassification()
        {
            return classification;
        }
        public string getReleaseDate()
        {
            return releaseDate;
        }

        public void addCopies(int copies)
        {
            copiesAvailable += copies;
        }

        public void movieBorrowed()
        {
            timesBorrowed++;
        }

        public void rentMovie()
        {
            if (!(copiesAvailable > 0)) 
            {
                Console.WriteLine("This DVD is unavailable.");
                return;
            }

            copiesAvailable -= 1;
        }
    }
}
