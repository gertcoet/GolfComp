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
            //Database.SetInitializer(new DataInitializer());
            Console.WriteLine("**** Fun with ADO.NET code First ****\n");
          //  Console.ReadLine();
            PrintAllGolfers();
            GetGolferAndAdd(5,99);
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

            using (var repo = new ScoreRepo())
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
     

       private static void GetGolferAndAdd(int holeNumber, int strokes)
        {
            using (var repo = new ScoreRepo())
            {
                var courseRound = repo.GetAll().FirstOrDefault().CourseRoud;
                var golfer = courseRound.CourseRoundHoles.FirstOrDefault().Golfer;
                var round = repo.GetOne(courseRound.CourseRoundId);
                var newCourseRoundHole = new CourseRoundHole
                {
                    Golfer = golfer,
                    CourseRoud = courseRound,
                    CourseHole = courseRound.GolfCourse.Holes.Where(x => x.HoleNumber == holeNumber).FirstOrDefault(),
                    Strokes = strokes
                };
                repo.Add(newCourseRoundHole);

            }
        }
    }
}
