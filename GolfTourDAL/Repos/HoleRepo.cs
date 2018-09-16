using System.Data.Entity;
using System.Threading.Tasks;
using GolfTourDAL.Model;

namespace GolfTourDAL.Repos
{
    public class HoleRepo : BaseRepo<CourseHole> , IRepo<CourseHole>
    {
        protected HoleRepo()
        {
            Table = Context.CourseHoles;
        }

        public int Delete(int id)
        {
            Context.Entry(new CourseHole {CourseHoleId = id}).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new CourseHole { CourseHoleId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
   
    }
}