using Bogus;
using DASTRU_Final_NatworkingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASTRU_Final_NatworkingProject.Services
{

    //Wa ni labot :)
    public static class GenerateDataService
    {
        public static void GenerateData()
        {
            //DEFAULT DATA
            DataContext.Packages.AddLast(new Package()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "PackageA",
                Code = "PA",
                Price = 12500
            });
            DataContext.Packages.AddLast(new Package()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "PackageB",
                Code = "PB",
                Price = 16000
            });
            DataContext.Packages.AddLast(new Package()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "PackageC",
                Code = "PC",
                Price = 24500
            });


            //
        }
    }

    public class DataGenerator
    {
        Faker<Member> MemberFaker;
        Faker<Package> PackageFaker;
        public DataGenerator()
        {
            //Randomizer.Seed = new Random(555);

            string[] packages = new[] { "PackageA", "PackageB", "PackageC", "PackageD", "PackageE", "PackageF" };
            PackageFaker = new Faker<Package>()
                .RuleFor(h => h.Id, f => f.Random.Guid().ToString())
                .RuleFor(q => q.Name, f => f.PickRandom(packages))
                .RuleFor(q => q.Code, (f, u) => u.Name)
                .RuleFor(q => q.Price, f => decimal.Parse(f.Commerce.Price(6000m, 24000m)));


            var memberId = 0;
            MemberFaker = new Faker<Member>()
                .RuleFor(h => h.Id, f => f.Random.Guid().ToString())
                .RuleFor(h => h.Name, f => f.Name.FirstName())
                .RuleFor(h => h.Code, f => ("230" + memberId++).ToString())
                .RuleFor(h => h.Package, f => PackageFaker.Generate(1).First())
                .RuleFor(h => h.PackageId, (f, u) => u.Package.Id);
                //.RuleFor(h => h.);
        }

        public Member GenerateName()
        {
            return MemberFaker.Generate();
        }

        public IEnumerable<Member> GenerateNames(int count)
        {
            var members = MemberFaker.GenerateForever().Take(count);

            return members;
        }
    }
}
