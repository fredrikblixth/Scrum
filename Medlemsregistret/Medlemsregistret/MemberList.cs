using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medlemsregistret
{
    static class MemberList
    {
        public static List<Member> AddMember(List<Member> members)
        {
            Console.Write("Ange förnamn: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Ange efternamn: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Ange telefonnummer: ");
            var phoneNumber = Console.ReadLine();

            try
            {
                var member = new Member(MembershipNumberCalculator.CalculateMembershipNumber(members), firstName, lastName);
                members.Add(member);
            }
            catch (Exception)
            {
                Console.WriteLine("Du måste ange för- och efternamn!");
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
                    Console.WriteLine();
                    Console.Write("Medlemsnummber: ");
                    Console.WriteLine(member.MembershipNumber);
                    Console.Write("Namn: ");
                    Console.WriteLine("{0} {1}", member.FirstName, member.LastName);
                    Console.Write("Telefon: ");
                    Console.WriteLine();
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

            while (!validNumber)
            {
                Console.WriteLine("Välj medlemsnummer: ");
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

        public static List<Member> EditMember(List<Member> members, int memberShipNumber) 
        {
            foreach(Member member in members)
            {
                if(member.MembershipNumber == memberShipNumber)
                {
                    Console.Write("Ange nytt förnamn: ");
                    member.FirstName = Console.ReadLine();

                    Console.Write("Ange nytt efternamn: ");
                    member.LastName = Console.ReadLine();

                    Console.Write("Ange nytt telefonnummer: ");
                    member.PhoneNumber = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Ingen medlem med nummer " + memberShipNumber + " kunde hittas!");
                }
            }

            return members;
        }

        public static List<Member> RemoveMember(List<Member> members, int membershipNumber)
        {
            foreach (Member member in members)
            {
                if (member.MembershipNumber == members)
                {

                }
            }
            return members;
        }
    }
}
