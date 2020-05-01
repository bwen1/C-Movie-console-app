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
        { /////////////////////// WHY IS THIS CONSTRUCTOR CALLED EVERYTIME NEW MEMBER IS REGISTERED? /////////////////////
            members = new Member[maxMemberNumber];
            iMemberNum = 0;
            Member testMember = new Member("Mike", "Chen", "1234 address", "1234", "1234"); //Test Member
            addNewMember(testMember);
            Console.WriteLine("CALL");

        }
        public void addNewMember(Member member)
        {
            if (member == null) return; // Member already registered
            if (iMemberNum == maxMemberNumber)
                Console.WriteLine("You have reached the maximum member limit."); // Reached max limit
            else 
            {
                members[iMemberNum++]= member;
                Console.WriteLine("Successfully registered. There are now " + iMemberNum + " registered members.");
            }
        }

        public string findPhoneNumber(string fullName)
        {
            if (members[0] != null)
            {


                foreach (Member person in members)
                {
                    if (fullName == person.name)
                    {
                        return person.phoneNumber;
                    }

                }
                return null;
            }
            else return null;
        }
    }
}
