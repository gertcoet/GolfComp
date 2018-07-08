using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GolfTourDAL.EF;
using GolfTourDAL.Repos;

namespace GolfCourseTestDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DataInitializer());
            Console.WriteLine("**** Fun with ADO.NET code First ****\n");
          //  Console.ReadLine();
            PrintAllGolfers();
            Console.ReadLine();
        }

        private static void PrintAllGolfers()
        {
            using (var repo = new GolferRepo())
            {
                foreach (var golfer in repo.GetAll())
                {
                    Console.WriteLine($"Golfer name = {golfer.Name}");
                }
            }
        }
    }
}
