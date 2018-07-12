using System.Data.Entity;
using System.Threading.Tasks;
using GolfTourDAL.Model;

namespace GolfTourDAL.Repos
{
    public class GolfCourseRepo : BaseRepo<GolfCourse> , IRepo<GolfCourse>
    {
        public GolfCourseRepo()
        {
            Table = Context.GolfCourses;
        }

        public int Delete(int id)
        {
            Context.Entry(new GolfCourse {GolfCourseId = id}).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new GolfCourse { GolfCourseId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}