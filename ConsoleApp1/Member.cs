using System;
using System.Collections.Generic;
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
        //private Movie array
        public Member(string firstName, string lastName, string address, string phoneNumber, string password)
        {
            this.name = firstName + " " + lastName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.userName = lastName + firstName;

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
    }
}
