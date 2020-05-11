using System;

namespace ConsoleApp1
{
    class Program
    {

        private static bool exitApp = false;
        private MemberMenu mm;
        private StaffMenu sm;
        private MemberCollection mc;
        private MovieCollection moc;


        public Program()
        {
            mc = new MemberCollection();
            moc = new MovieCollection();
            mm = new MemberMenu(this);
            sm = new StaffMenu(this);
            

        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Movie testMovie = new Movie("Jaws", "Person", "Director", "90", "Horror", "General (G)", "1600", 3);
            Member testMember = new Member("Mike", "Chen", "1234 Pl", "1234567890", "1234");
            p.moc.add(testMovie);
            p.mc.addNewMember(testMember);

            while (exitApp == false)
            {
                p.mainMenu();

            }

        }
        
        public MovieCollection getMovieCollection()
        {
            return moc;
        }

        public MemberCollection getMemberCollection()
        {
            return mc;
        }

        // Main Menu
        public void mainMenu()
        {
            Console.WriteLine("\nWelcome to the Community Library.");
            Console.WriteLine("===========Main Menu===========");
            Console.WriteLine(" 1. Staff Login");
            Console.WriteLine(" 2. Member Login");
            Console.WriteLine(" 0. Exit");
            Console.WriteLine("===============================");
       
            switch (menuSetUp())
            {
                case 0:
                    exitApp = true;
                    break;

                case 1:
                    sm.staffLogin();
                    break;

                case 2:
                    mm.memberLogin();
                    break;
                   
            }

        }
        int menuSetUp()
        {
            Console.WriteLine("\n\nPlease make a selection (1-2, or 0 to exit):");
            string stringSelection = Console.ReadLine();
            int intSelection;

            // If user input is not in specified range or not an int, user will be prompted to re-input 
            while (!int.TryParse(stringSelection, out intSelection) || !((intSelection <= 2) && (intSelection >= 0)))
            {
                Console.Write("Error: Invalid Input\n");
                Console.WriteLine("\n\nPlease make a selection (1-2, or 0 to exit):");
                stringSelection = Console.ReadLine();

            }
            return intSelection;

        }


    }
}
