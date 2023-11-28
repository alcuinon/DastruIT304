using DASTRU_Final_NatworkingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alcuino.ConsoleWriter472;

namespace DASTRU_Final_NatworkingProject.Services
{
    public static class MemberService
    {
        public static void AddMemberPage()
        {
            ConsoleWriter.WriteHeader("Add Member Page", ConsoleColor.White, 42);

            Member member = new Member();

            member.Id = Guid.NewGuid().ToString();

            Console.Write("\nName \t\t> ");
            member.Name = ConsoleWriter.ReadLine(ConsoleColor.Cyan);

            Console.Write("Package Code \t> ");
            string packageCode = ConsoleWriter.ReadLine(ConsoleColor.Cyan);

            //Check if package code exist
            Package package = DataContext.Packages.FirstOrDefault(q => q.Code.ToLower() == packageCode.ToLower());
            if (package == null)
            {
                ConsoleWriter.WriteError("Package not found!");
                return;
            }
            else
            {
                member.PackageId = package.Id;
                member.Package = package;
            }

            Console.Write("Member Code \t> ");
            member.Code = ConsoleWriter.ReadLine(ConsoleColor.Cyan);

            Console.Write("Recruiter Code \t> ");
            member.RecruiterCode = ConsoleWriter.ReadLine(ConsoleColor.Cyan);

            AddMember(member);

            Console.ReadKey();
        }

        public static void AddMember(Member member) 
        {
            //check if Recruiter code exist
            Member recruiter = DataContext.Members.FirstOrDefault(q => q.Code.ToLower() == member.RecruiterCode?.ToLower());
            if (recruiter == null)
            {
                if (DataContext.Members.Any())
                {
                    ConsoleWriter.WriteError("Recruiter not found!");
                    return;
                }
            }
            else
            {
                member.Recruiter = recruiter;
                //company earning
                EarningService.CompanyEarning(member);
                //recruiter earning
                EarningService.DirectEarning(member);
                //upline earning
                EarningService.UplineEarning(member);
            }

            DataContext.Members.AddLast(member);

            ConsoleWriter.WriteLine("Successfully Added!", ConsoleColor.DarkGreen);
        }
    }
}
