using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MemberCollection
    {
        private const int maxMemberNumber = 10;
        public Member[] members ;
        private int iMemberNum;

        public MemberCollection()
        { 
            members = new Member[maxMemberNumber];
            iMemberNum = 0;
        }

        public bool checkMemberExists(string name)
        {
            for (int i = 0; i < iMemberNum; i++)
            {
                if (name.Equals(members[i].getName()))
                {
                    return true;
                }
            }
            return false;
        }
        public void addNewMember(Member member)
        {
            //Console.WriteLine("iMemberNum is: " + iMemberNum);
            //Console.WriteLine(member.getUserName());
            if (member == null)
            {
                Console.WriteLine("Something went wrong, perhaps the member is already registered.");
                return; // Member already registered
            }
                

            if (iMemberNum == maxMemberNumber)
            {
                Console.WriteLine("You have reached the maximum member limit."); // Reached max limit
                return;
            }
                
            else 
            {
                members[iMemberNum]= member;
                iMemberNum++;
                Console.WriteLine("Successfully registered. There are now " + iMemberNum + " registered members.");
            }
            //Console.WriteLine("iMemberNum is: " + iMemberNum);
            //Console.WriteLine("Member username is " + members[iMemberNum - 1].getUserName());
        }

        public string findPhoneNumber(string fullName)
        {
            if (members[0] != null)
            {
                for (int i = 0; i < iMemberNum; i++)
                {
                    if (fullName.Equals(members[i].getName()))
                    {
                        return members[i].getPhoneNumber();
                    }
                }
                return null;
            }
            else return null;
        }

        public Member getMemberFromName(string name)
        {
            if (members[0] != null)
            {
                for (int i = 0; i < iMemberNum; i++)
                {
                    if (members[i].getName() == name)
                    {
                        return members[i];
                    }
                }
                return null;
            }
            else return null;
        }

        public Member logIn(string username, string password)
        {

            if (members[0] != null)
            {
                for (int i = 0; i < iMemberNum; i++)
                {
                    if ((username == members[i].getUserName()) && (password == members[i].getPassword()))
                    {
                        return members[i];
                    }
                }
                Console.WriteLine("\nLogon information incorrect.");
                return null;
            }

            else
            {
                Console.WriteLine("\nThere are no members registered.");
                return null;
            }
        }
    }
}
