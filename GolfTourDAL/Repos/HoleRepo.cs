using System.Data.Entity;
using System.Threading.Tasks;
using GolfTourDAL.Model;

namespace GolfTourDAL.Repos
{
    public class HoleRepo : BaseRepo<Hole> , IRepo<Hole>
    {
        protected HoleRepo()
        {
            Table = Context.Holes;
        }

        public int Delete(int id)
        {
            Context.Entry(new Hole {HoleId = id}).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Hole { HoleId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}