using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GolfTourDAL.EF;
using GolfTourDAL.Model;
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
            //using (var repo = new GolferRepo())
            //{
            //    foreach (var golfer in repo.GetAll())
            //    {
            //        Console.WriteLine($"Golfer name = {golfer.Name}");
            //    }
            //}

            using (var golfCourse = new GolfCourseRepo())
            {
                var course = golfCourse.GetAll().First();
                foreach (var hole in course.Holes)
                {
                    Console.WriteLine($"Course {course.Name} hole {hole.HoleNumber.ToString()} - par {hole.Par}");
                }

            }
        }
    }
}
