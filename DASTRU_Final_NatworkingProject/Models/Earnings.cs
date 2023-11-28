using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASTRU_Final_NatworkingProject.Models
{
    public class Earnings
    {
        public string Id { get; set; }
        public string FromId { get; set; } //could be Company or Member
        public string ToId { get; set; }
        public decimal Earning { get; set; }
        public Member From { get; set; }
        public Member To { get; set; }
    }
}
