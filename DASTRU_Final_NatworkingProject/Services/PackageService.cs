using DASTRU_Final_NatworkingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Alcuino.ConsoleWriter472;

namespace DASTRU_Final_NatworkingProject.Services
{
    public static class PackageService
    {
        public static void AddPackagePage()
        {
            ConsoleWriter.WriteHeader("Add Package Page", ConsoleColor.White, 42);

            Package package = new Package();

            package.Id = Guid.NewGuid().ToString();

            Console.Write("\nName: ");
            package.Name = Console.ReadLine();
            Console.Write("Code: ");
            package.Code = Console.ReadLine();
            Console.Write("Price: ");
            package.Price = decimal.Parse(Console.ReadLine());

            DataContext.Packages.AddLast(package);

            ConsoleWriter.WriteLine("Successfully Added!", ConsoleColor.DarkGreen);

            Console.ReadKey();
        }

        public static void UpdatePackagePage()
        {
            ConsoleWriter.WriteHeader("Update Package Price Page", ConsoleColor.White, 42);

            //show the list of packages
            Console.WriteLine("\nInstructions:");
            Console.WriteLine($">> Enter 'exit' to exit.");
            foreach (var package in DataContext.Packages)
            {
                Console.WriteLine($">> Enter '{package.Code}' to update {package.Name}.");
            }

            Console.WriteLine("\nPlease make a selection: ");
            string userInput = Console.ReadLine();

            if (userInput == "exit") return;

            Package selectedPackage = DataContext.Packages.FirstOrDefault(q => q.Code == userInput);
            if (selectedPackage == null)
            {
                ConsoleWriter.WriteError("Package Not Found!");
                return;
            }
            else
            {
                DataContext.Packages.Remove(selectedPackage);
                ConsoleWriter.Write("Price: ");
                selectedPackage.Price = decimal.Parse(Console.ReadLine());
                DataContext.Packages.AddLast(selectedPackage);
            }

            Console.ReadKey();
        }
    }
}
