using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Member
    {
        public string name;
        public string address;
        public string phoneNumber;
        public string password;
        public string userName;
        public Member(string firstName, string lastName, string address, string phoneNumber, string password)
        {
            this.name = firstName + " " + lastName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.userName = lastName + firstName;

        }
    }
}
