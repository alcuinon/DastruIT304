using DASTRU_Final_NatworkingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alcuino.ConsoleWriter472;

namespace DASTRU_Final_NatworkingProject.Services
{
    public static class EarningService
    {
        public static readonly double DirectEarningIncentivePercentage = 0.05;
        public static readonly decimal AncestorEarningIncentive = 100;
        
        public static void CompanyEarning(Member newMember)
        {
            Earnings earning = new Earnings()
            {
                Id = Guid.NewGuid().ToString(),
                FromId = newMember.Id,
                From = newMember,
                ToId = null,
                Earning = newMember.Package.Price
            };

            DataContext.Earnings.AddLast(earning);
        }

        public static void DirectEarning(Member member)
        {
            Earnings earning = new Earnings()
            {
                Id = Guid.NewGuid().ToString(),
                FromId = null,
                ToId = member.Recruiter.Id,
                To = member.Recruiter,
                Earning = member.Package.Price * 0.05m
            };

            DataContext.Earnings.AddLast(earning);
        }

        public static void UplineEarning(Member newMember)
        {
            //Loop
            Member uplineMember = newMember.Recruiter;
            if(uplineMember != null)
            {
                Earnings earning = new Earnings()
                {
                    Id = Guid.NewGuid().ToString(),
                    FromId = null,
                    ToId = uplineMember.Id,
                    To = uplineMember,
                    Earning = AncestorEarningIncentive
                };

                DataContext.Earnings.AddLast(earning);

                UplineEarning(uplineMember);
            }
        }

        public static void DisplayEarningPage()
        {
            ConsoleWriter.WriteHeader("Company Earning Report", ConsoleColor.DarkYellow, ConsoleColor.Black, 67);

            ConsoleWriter.WriteColumn(new string[] { "ID", "FROM", "TO", "EARNING" }, Align.Center, 16, ConsoleColor.Magenta);
            foreach (var earn in DataContext.Earnings.Where(q=> q.ToId == null))
            {
                string from = earn.From == null ? "Company" : earn.From.Name;
                string to = earn.To == null ? "Company" : earn.To.Name;

                string[] cols = new string[] { earn.Id.Substring(0, 8), from, to, earn.Earning.ToString("n2") };
                ConsoleWriter.WriteColumn(cols, Align.Center, 16, ConsoleColor.DarkCyan);

            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
