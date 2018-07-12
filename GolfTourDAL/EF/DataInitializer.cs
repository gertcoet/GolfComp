using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GolfTourDAL.Model;

namespace GolfTourDAL.EF
{
    public class DataInitializer : DropCreateDatabaseAlways<GolfTourEntities>
    {
        protected override void Seed(GolfTourEntities context)
        {
            var golfers = new List<Golfer>
            {
                new Golfer {Name = "Gert", Surname = "Coetzee"},
                new Golfer {Name = "Craig", Surname = "Lazar"},
                new Golfer {Name = "Hano", Surname = "Pano"}
            };
            golfers.ForEach(g => context.Golfers.Add(g));

            var testCourse = new GolfCourse {Name = "Durban Country Club"};
            context.GolfCourses.Add(testCourse);

            var holes = new List<CourseHole>
            {
                new CourseHole {HoleNumber = 1, Par = 4, Stroke = 1},
                new CourseHole {HoleNumber = 2, Par = 4, Stroke = 2},
                new CourseHole {HoleNumber = 3, Par = 3, Stroke = 3},
                new CourseHole {HoleNumber = 4, Par = 4, Stroke = 4},
                new CourseHole {HoleNumber = 5, Par = 3, Stroke = 5},
                new CourseHole {HoleNumber = 6, Par = 4, Stroke = 6},
                new CourseHole {HoleNumber = 7, Par = 5, Stroke = 7},
                new CourseHole {HoleNumber = 8, Par = 4, Stroke = 8},
                new CourseHole {HoleNumber = 9, Par = 5, Stroke = 9}
            };

            var courseRound = new CourseRound
            {
                Date = DateTime.Now.Subtract(new TimeSpan(0, 1, 0)),
                ScoreType = ScoreType.MatchPlay
            };

            var courseRoundHoles = new List<CourseRoundHole>
            {
                new CourseRoundHole
                {
                    CourseRoud = courseRound,
                    CourseHole = courseRound.GolfCourse.Holes.Where(h => h.HoleNumber == 1).FirstOrDefault(),
                    Golfer = golfers[1],
                    Strokes = 4
                },
                new CourseRoundHole
                {
                    CourseRoud = courseRound,
                    CourseHole = courseRound.GolfCourse.Holes.Where(h => h.HoleNumber == 1).FirstOrDefault(),
                    Golfer = golfers[2],
                    Strokes = 5
                },
                new CourseRoundHole
                {
                    CourseRoud = courseRound,
                    CourseHole = courseRound.GolfCourse.Holes.Where(h => h.HoleNumber == 2).FirstOrDefault(),
                    Golfer = golfers[1],
                    Strokes = 3
                },
                new CourseRoundHole
                {
                    CourseRoud = courseRound,
                    CourseHole = courseRound.GolfCourse.Holes.Where(h => h.HoleNumber == 2).FirstOrDefault(),
                    Golfer = golfers[2],
                    Strokes = 4
                },
                new CourseRoundHole
                {
                    CourseRoud = courseRound,
                    CourseHole = courseRound.GolfCourse.Holes.Where(h => h.HoleNumber == 3).FirstOrDefault(),
                    Golfer = golfers[2],
                    Strokes = 6
                },
                new CourseRoundHole
                {
                    CourseRoud = courseRound,
                    CourseHole = courseRound.GolfCourse.Holes.Where(h => h.HoleNumber == 3).FirstOrDefault(),
                    Golfer = golfers[2],
                    Strokes = 5
                }
            };

            courseRound.CourseRoundHoles = courseRoundHoles;
            testCourse.Holes = holes;
            context.SaveChanges();
        }
    }
}