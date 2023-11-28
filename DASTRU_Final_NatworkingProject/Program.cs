using DASTRU_Final_NatworkingProject.Models;
using DASTRU_Final_NatworkingProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Alcuino.ConsoleWriter472;

namespace DASTRU_Final_NatworkingProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* NETWORKING
                User can add, edit, delete (but not totally deleted just disable it) Membership Package
                User can add new Member with Package selected + recruiter if able
                User can see individual earnings
                User can see company earnings
                User can add profit share (money) to all Members base on 5% of Company income
                
                Member/Account [Partially Done]
                Package [Partially Done]
                Earnings [Partially Done]
                
                note: should be able to add recruiter base on MemberCode which will be the recruiterCode
                note: ditribute the 5% of company eaning and will be devided by each members

                todo
                1. each added members should also add Incentive to the direct recruiter, 
                incentive will be differ base on the package selected of direct recruiter
                2. each added members should also add Incentive to the upline members, fix to all upline
                
                Models - To Stores all the model classes
                
                
                Package -- Create Package First
                Member -- Create Member -- Earning will involve
             */

            //Dont mind this one!
            DataContext.GenerateTestData();

            ConsoleWriter.IsTypeWriterMode = true;
            while (true)
            {
                Console.Clear();
                ConsoleWriter.WriteHeader("Welcome to Networking App!", ConsoleColor.DarkCyan, ConsoleColor.Black, 56, "*");

                Console.WriteLine("\nInstructions:");
                Console.WriteLine(">> Enter '1' to Add Package.");
                Console.WriteLine(">> Enter '2' to Update Package.");
                Console.WriteLine(">> Enter '3' to Add Member.");
                Console.WriteLine(">> Enter '4' to Display Company Earning.");
                Console.WriteLine(">> Enter '5' to exit.");

                Console.Write("\nPlease make a selection: ");
                var userInput = int.Parse(Console.ReadLine());

                if (userInput == (int)MenuEnum.Exit) break;

                switch ((MenuEnum)userInput)
                {
                    case MenuEnum.AddPackage: PackageService.AddPackagePage(); break;
                    case MenuEnum.UpdatePackage: PackageService.UpdatePackagePage(); break;
                    case MenuEnum.AddMember: MemberService.AddMemberPage(); break;
                    case MenuEnum.DisplayCompanyEarning: EarningService.DisplayEarningPage(); break;
                    default: break;
                }
            }

        }
    }
}
