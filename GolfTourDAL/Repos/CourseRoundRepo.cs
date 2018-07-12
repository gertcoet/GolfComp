using System.Data.Entity;
using System.Threading.Tasks;
using GolfTourDAL.Model;

namespace GolfTourDAL.Repos
{
    public class CourseRoundRepo : BaseRepo<CourseRound> , IRepo<CourseRound>
    {
        public CourseRoundRepo()
        {
            Table = Context.CourseRound;
        }

        public int Delete(int id)
        {
            Context.Entry(new CourseRound {CourseRoundId = id}).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new CourseRound { CourseRoundId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}