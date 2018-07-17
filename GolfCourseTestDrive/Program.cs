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

            using (var repo = new CourseRoundHoleRepo())
            {
                var roundDetails = repo.GetAll();
                var course = roundDetails.FirstOrDefault().CourseHole.GolfCourse.Name;
                var golfRound = roundDetails.FirstOrDefault().CourseRoud;

                foreach (var hole in roundDetails.FirstOrDefault().CourseRoud.CourseRoundHoles)
                {
                    Console.WriteLine($"Course - {hole.CourseHole.GolfCourse.Name}, Golfer - {hole.Golfer.Name}, Hole - {hole.CourseHole.HoleNumber} , Par - {hole.CourseHole.Par} , Strokes - {hole.Strokes}");
                }

            }
        }
    }
}
