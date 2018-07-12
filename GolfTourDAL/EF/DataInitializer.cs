using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GolfTourDAL.Model;

namespace GolfTourDAL.EF
{
    public class DataInitializer : DropCreateDatabaseAlways<GolfTourEntities>
    {
        protected override void Seed(GolfTourEntities context)
        {
            var golfers = new List<Golfer>
            {
                new Golfer {Name = "Gert", Surname = "Coetzee",},
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


            testCourse.Holes = holes;

            context.SaveChanges();
        }
    }
}
