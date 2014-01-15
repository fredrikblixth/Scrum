using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregistret
{
    static class MemberListController
    {
        public static List<Member> AddMember(List<Member> members)
        {
            Console.Write("Ange förnamn: ");
            var firstName = Console.ReadLine();

            Console.Write("Ange efternamn: ");
            var lastName = Console.ReadLine();

            Console.Write("Ange telefonnummer: ");
            var phoneNumber = Console.ReadLine();

            try
            {
                var member = new Member(MembershipNumberCalculator.CalculateMembershipNumber(members), firstName, lastName);
                members.Add(member);
            }
            catch (Exception)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Du måste ange för- och efternamn!");
                Console.ResetColor();
            }

            return members;
        }

        public static void ListMembers(List<Member> members) 
        {
            if(members.Count > 0)
            { 
                Console.WriteLine("Medlemsregister:");
                Console.WriteLine("===========================");
                foreach (Member member in members) 
                {
                    Console.WriteLine("{0}: {1} {2}", member.MembershipNumber, member.FirstName, member.LastName);
                }
                Console.WriteLine();
                Console.WriteLine("===========================");
            }
            else
            {
                Console.WriteLine("Det finns inga medlemmar i registret!");
            }
        }

        public static int ChooseMember(List<Member> members)
        {
            var validNumber = false;
            var chosenMemberNumber = 0;
            MemberListController.ListMembers(members);

            while (!validNumber)
            {
                Console.Write("Välj medlem med nummer: ");
                try
                {
                    chosenMemberNumber = Int32.Parse(Console.ReadLine());
                    validNumber = true;
                }
                catch(Exception)
                {
                    Console.WriteLine("Kan inte tolkas som ett giltigt medlemsnummer. Ange endast siffror");
                }
            }

            foreach (Member member in members)
            {
                if(member.MembershipNumber == chosenMemberNumber)
                {
                    return chosenMemberNumber;
                }
            }

            return chosenMemberNumber;
        }

        public static List<Member> EditMember(List<Member> members, int membershipNumber) 
        {
            foreach(Member member in members)
            {
                if(member.MembershipNumber == membershipNumber)
                {
                    Console.Write("Ange nytt förnamn: ");
                    member.FirstName = Console.ReadLine();

                    Console.Write("Ange nytt efternamn: ");
                    member.LastName = Console.ReadLine();

                    Console.Write("Ange nytt telefonnummer: ");
                    member.PhoneNumber = Console.ReadLine();

                    return members;
                }
            }
            Console.WriteLine("Ingen medlem med nummer " + membershipNumber + " kunde hittas!");
            return members;
        }

        public static List<Member> RemoveMember(List<Member> members, int membershipNumber)
        {
            foreach (Member member in members)
            {
                if (member.MembershipNumber == membershipNumber)
                {
                    members.Remove(member);
                    Console.WriteLine("Medlemmen borttagen!");
                    return members;
                }
            }

            Console.WriteLine("Ingen medlem med det numret hittades! Avbryter..");
            return members;
        }
        public static void ViewMemberDetails(List<Member> members, int membershipNumber)
        {
            var isMemberFound = false;

            foreach (Member member in members)
            {
                if (member.MembershipNumber == membershipNumber)
                {
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Medlemsnummer: {0}", member.MembershipNumber);
                    Console.WriteLine("Förnamn: {0}", member.FirstName);
                    Console.WriteLine("Efternam: {0}", member.LastName);
                    Console.WriteLine("Telefon: {0}", member.PhoneNumber);
                    Console.WriteLine("=========================================");
                    isMemberFound = true;
                }
            }
            if(!isMemberFound)
            {
                Console.WriteLine("Ingen medlem med det nummer kunde hittas!");
            }
        }
    }
}
