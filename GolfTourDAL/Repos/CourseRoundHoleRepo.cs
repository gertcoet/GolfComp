using System.Data.Entity;
using System.Threading.Tasks;
using GolfTourDAL.Model;

namespace GolfTourDAL.Repos
{
    public class ScoreRepo : BaseRepo<CourseRoundHole> , IRepo<CourseRoundHole>
    {
        public ScoreRepo()
        {
            Table = Context.CourseRoundHoles;
        }
        
        public int Delete(int id)
        {
            Context.Entry(new CourseRoundHole {CourseRoudHoleId = id}).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new CourseRoundHole { CourseRoudHoleId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}