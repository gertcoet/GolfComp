using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GolfTourDAL.Model;

namespace GolfTourDAL.Repos
{
    public class GolferRepo : BaseRepo<Golfer>, IRepo<Golfer>
    {
        public GolferRepo()
        {
            Table = Context.Golfers;
        }

        public int Delete(int id)
        {
            Context.Entry(new Golfer {GolferId = id}).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Golfer { GolferId = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
