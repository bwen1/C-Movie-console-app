using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1
{
    class Node
    {
        
        private Node leftNode;
        private Node rightNode;
        private Node parentNode;
        private Movie data;
        private static Movie[] movieArray;
        private static int moviesInBST = 0;
        private static int index;

        public Node(Node p)
        {
            parentNode = p;
            data = null;
            leftNode = null;
            rightNode = null;

        }

        public Node getNodeFromMovie(Movie m) // TODO
        {
            return null;
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

        public void setParentNode(Node n)
        {
            parentNode = n;
        }

        public Node getParentNode()
        {
            return parentNode;
        }

        public void setMovie(Movie movie)
        {
            data = movie;
            moviesInBST++; // Count how many movies in BST
        }

        public Movie getMovie()
        {
            return data;
        }


        public string getTitle()
        {
            return data.getTitle();
        }

        public char getMySide() // Return which side of tree node is on
        {
            if (parentNode == null) return 'n';
            if (parentNode.getLeftNode() == this) return 'l';
            return 'r';
        }

        public void removeSelf(MovieCollection moc) // Remove node
        {
            Node newChild = null;
            Node newParent = null;
            char mySide;
            if(leftNode == null)
            {
                newChild = rightNode;
            }
            else if (rightNode == null)
            {
                newChild = leftNode;
            }
            else
            {
                newChild = rightNode;

                Node leftMostNodeofRightChild = rightNode.findLeftMostNode();
                leftNode.setParentNode(leftMostNodeofRightChild);
                leftMostNodeofRightChild.setLeftNode(leftNode);

            }
            if (parentNode != null) {
                newParent = parentNode;
                mySide = getMySide();
                if (mySide == 'l')
                    newParent.setLeftNode(newChild);
                else
                    newParent.setRightNode(newChild);
            } else
            {
                moc.setNewRoot(newChild);
            }


            if (newChild != null)
            {
                newChild.setParentNode(newParent);
            }



        }

        public Node findLeftMostNode()
        {
            if (leftNode == null)
                return this;
            else
                return leftNode.findLeftMostNode();

        }

        public void displayme() // Method used for testing BST
        {
            Console.WriteLine(data.getTitle());
            if(leftNode != null)
            {
                Console.WriteLine("(Left: ");
                leftNode.displayme();
                Console.WriteLine("endLeft)");

            }
            if (rightNode != null)
            {
                Console.WriteLine("(Right: ");
                rightNode.displayme();
                Console.WriteLine("endRight)");

            }
        }

        public void displayAllMovies() // Displays all movies
        {
            Console.WriteLine("\n\nTitle: " + data.getTitle());
            Console.WriteLine("Starring: " + data.getStarring());
            Console.WriteLine("Director: " + data.getDirector());
            Console.WriteLine("Genre: " + data.getGenre());
            Console.WriteLine("Classification: " + data.getClassification());
            Console.WriteLine("Duration: " + data.getDuration());
            Console.WriteLine("Release Date: " + data.getReleaseDate());
            Console.WriteLine("Copies Available: " + data.getCopiesAvailable());
            Console.WriteLine("Times Borrowed: " + data.getTimesBorrowed());
            if (leftNode != null)
            {
                leftNode.displayAllMovies();

            }
            if (rightNode != null)
            {
                rightNode.displayAllMovies();
            }
        }

        public Node findNodeFromTitle(string title) // Find node from title // Not tested
        {
            if (data.getTitle() == title)
            {
                return getNodeFromMovie(data);
            }
            if (leftNode != null)
            {
                leftNode.findNodeFromTitle(title);
            }
            if (rightNode != null)
            {
                rightNode.findNodeFromTitle(title);
            }

            return null;
        }

        public Movie[] getMovieArray() // Convert BST to array
        {
            movieArray = new Movie[moviesInBST];
            index = 0;
            recursiveIterate();
            index = 0;
            return movieArray;
        }

        public void recursiveIterate() // Function used by getMovieArray()
        { 
            movieArray[index] = data;
            index++;
            if (leftNode != null)
            {
                leftNode.recursiveIterate();
            }
            if (rightNode != null)
            {
                rightNode.recursiveIterate();
            }
        }
    }



    class MovieCollection
    {
        private Node root;
        private Movie[] movieArray;

        public MovieCollection()
        {
            root = null;
        }

        public void displayMovies() // Test function
        {
            if (root == null)
            {
                Console.WriteLine("There are no movies.");
            }
            else
                root.displayAllMovies();
        }

        public void topTenArray()
        {
            if (root == null)
            {
                Console.WriteLine("There are no movies.");
            }
            else
                movieArray = root.getMovieArray();

            quickSortDescending(movieArray, 0, movieArray.Length - 1);

            foreach (Movie movie in movieArray)
            {
                Console.WriteLine(movie.getTitle() + " borrowed " + movie.getTimesBorrowed() + " times.");
            }
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

        public void setNewRoot(Node n)
        {
            root = n;
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

        public bool movieExists(string newTitle) // Check if movie exists
        {

            if (getMovieByTitle(newTitle) == null)
            {
                return false;
            }

            return true;
        }

        public bool removeMovie(string movie) // To Do
        {
            Node nodeToRemove = root.findNodeFromTitle(movie);
            //nodeToRemove.removeSelf();
     
            return true;
        }



        private void quickSortDescending(Movie[] titles, int start, int end) // Reversed quicksort
        {
            if (start < end)
            {
                int pivot = partition(titles, start, end);

                if (pivot > 1)
                {
                    quickSortDescending(titles, start, pivot - 1);
                }
                if (pivot + 1 < end)
                {
                    quickSortDescending(titles, pivot + 1, end);
                }
            }

        }

        private int partition(Movie[] titles, int start, int end) // Partioning function for quickSortDescending()
        {
            int pivot = titles[start].getTimesBorrowed();
            while (true)
            {
                while (titles[start].getTimesBorrowed() > pivot)
                {
                    start++;
                }

                while (titles[end].getTimesBorrowed() < pivot)
                {
                    end--;
                }

                if (start < end)
                {
                    if (titles[start].getTimesBorrowed() == titles[end].getTimesBorrowed())
                    {
                        return end;
                    }

                    Movie temp = titles[start];
                    titles[start] = titles[end];
                    titles[end] = temp;
                }
                else
                {
                    return end;
                }
            }
        }
    } 
}
