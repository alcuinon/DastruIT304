using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASTRU_Final_NatworkingProject.Models
{
    public class Member
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string RecruiterCode { get; set; }
        public string PackageId { get; set; }
        public Package Package { get; set; }
        public Member Recruiter { get; set; }
    }
}
