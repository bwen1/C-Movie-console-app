using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ConsoleApp1
{
    class Node
    {
        private Node leftNode;
        private Node rightNode;
        private Node parentNode;
        private Movie data;

        public Node(Node p)
        {
            parentNode = p;
            data = null;
            leftNode = null;
            rightNode = null;

        }

        public Node getLeftNode()
        {
            return leftNode;
        }

        public Node getRightNode()
        {
            return rightNode;
        }

        public void setLeftNode(Node n)
        {
            leftNode = n;
        }

        public void setRightNode(Node n)
        {
            rightNode = n;
        }

        public Node getParentNode()
        {
            return parentNode;
        }

        public void setMovie(Movie movie)
        {
            data = movie;
        }

        public Movie getMovie()
        {
            return data;
        }


        public string getTitle()
        {
            return data.getTitle();
        }


        
    }

    class MovieCollection
    {
        private Node root;

        public MovieCollection()
        {
            root = null;
        }



        public bool add(Movie movie)
        {
            Node before = null;
            Node after = this.root;
            if (movie == null)
            {
                return false;
            }

            while (after != null)
            {
                before = after;
                if (string.Compare(movie.getTitle(), after.getTitle()) == -1) //Is new node in left tree? 
                    after = after.getLeftNode();
                else if (string.Compare(movie.getTitle(), after.getTitle()) == 1) //Is new node in right tree?
                    after = after.getRightNode();
                else
                {
                    return false; // Movie exists
                }
            }

            Node newNode = new Node(before);
            newNode.setMovie(movie);


            if (this.root == null) //Tree is empty
                this.root = newNode;
            else
            {
                if (string.Compare(movie.getTitle(), before.getTitle()) == -1)
                    before.setLeftNode(newNode);
                else
                    before.setRightNode(newNode);
            }

            return true;
        }


        public bool deleteMovie(Movie movie)

        {
            // TODO
            return true;

        }


        public Movie getMovieByTitle(string movieTitle)
        {
            Node before = null;
            Node after = this.root;


            while (after != null)
            {
                before = after;
                if (string.Compare(movieTitle, after.getTitle()) == -1) //Is new node in left tree? 
                    after = after.getLeftNode();
                else if (string.Compare(movieTitle, after.getTitle()) == 1) //Is new node in right tree?
                    after = after.getRightNode();
                else
                {
                    return before.getMovie(); // Movie exists
                }
            }

            return null; // Movie doesn't exist
        }

        public bool movieExists(string newTitle)
        {

            if (getMovieByTitle(newTitle) == null)
            {
                return false;
            }

            return true;
        }




    }
}
