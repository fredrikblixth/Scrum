using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Medlemsregistret
{
    class Program
    {
        static void Main(string[] args)
        {
            var menuChoice = -1;
            var memberList = new List<Member>();
            var memberRepository = new MemberRepository("members.xml");

            if(File.Exists("members.xml"))
            {
                memberList = memberRepository.LoadMembers();
            }

            do
            {
                menuChoice = GetMenuChoice();
                switch(menuChoice)
                {
                    case 0:
                        break;
                    case 1:
                        memberList = MemberListController.AddMember(memberList);
                        memberRepository.SaveMembers(memberList);
                        ContinueOnKeyPressed();
                        break;
                    case 2:
                        MemberListController.ListMembers(memberList);
                        ContinueOnKeyPressed();
                        break;
                    case 3:
                        var chosenMember = MemberListController.ChooseMember(memberList);
                        memberList = MemberListController.EditMember(memberList, chosenMember);
                        memberRepository.SaveMembers(memberList);
                        ContinueOnKeyPressed();
                        break;
                    case 4:
                        chosenMember = MemberListController.ChooseMember(memberList);
                        MemberListController.ViewMemberDetails(memberList, chosenMember);
                        ContinueOnKeyPressed();
                        break;
                    case 5:
                        chosenMember = MemberListController.ChooseMember(memberList);
                        memberList = MemberListController.RemoveMember(memberList, chosenMember);
                        memberRepository.SaveMembers(memberList);
                        ContinueOnKeyPressed();
                        break;
                    default:
                        throw new NotImplementedException();
                }
                memberList = memberRepository.LoadMembers();
            }
            while(menuChoice != 0);

        }

        public static int GetMenuChoice()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("---------------------------------");
            Console.WriteLine("-        Medlemsregistret       -");
            Console.WriteLine("---------------------------------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("0. Avsluta.");
            Console.WriteLine("1. Skapa ny medlem.");
            Console.WriteLine("2. Lista medlemmar.");
            Console.WriteLine("3. Redigera medlem.");
            Console.WriteLine("4. Visa medlemsdetaljer.");
            Console.WriteLine("5. Ta bort medlem.");
            Console.WriteLine();

            int menuChoice = -1;
            bool acceptableMenuChoice = false;

            while (!acceptableMenuChoice)
            {
                Console.Write("Ange val 0-8: ");
                var userInput = Console.ReadLine();

                try
                {
                    menuChoice = Int32.Parse(userInput);

                    if (menuChoice < 0 || menuChoice > 5)
                    {
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("FEL! Kan inte tolkas som ett giltigt menyval!");
                        Console.ResetColor();
                    }
                    else
                    {
                        acceptableMenuChoice = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("FEL! Kan inte tolkas som ett giltigt värde! Ange heltal i intervallet 0-5");
                    Console.ResetColor();
                }
            }

            return menuChoice;
        }
        public static void ContinueOnKeyPressed()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
            Console.WriteLine("Tryck på en tangent för att fortsätta.");
            Console.ResetColor();
            Console.ReadKey();
        }
    }

}
