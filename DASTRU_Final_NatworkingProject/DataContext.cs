using DASTRU_Final_NatworkingProject.Models;
using DASTRU_Final_NatworkingProject.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DASTRU_Final_NatworkingProject
{
    public static class DataContext
    {
        public static LinkedList<Package> Packages = new LinkedList<Package>();
        public static LinkedList<Member> Members = new LinkedList<Member>();
        public static LinkedList<Earnings> Earnings = new LinkedList<Earnings>();


        #region Test Data
        public static void GenerateTestData()
        {
            DataGenerator dataGenerator = new DataGenerator();
            var members = dataGenerator.GenerateNames(10);

            var memberAdded = new List<Member>();
            Random random = new Random();
            foreach (var member in members)
            {
                var rand = random.Next(0, memberAdded.Count);
                var selected = memberAdded
                    .Where(q => q.Id != member.Id)
                    .Skip(rand)
                    .FirstOrDefault();
                member.Recruiter = selected;
                member.RecruiterCode = selected?.Code;
                memberAdded.Add(member);
                MemberService.AddMember(member);
            }
        }
        #endregion
    }
}
