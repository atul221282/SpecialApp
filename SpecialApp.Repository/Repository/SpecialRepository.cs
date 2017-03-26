using Microsoft.EntityFrameworkCore;
using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Repository.Repository
{
    public class SpecialRepository : Repository<Special>, ISpecialRepository
    {
        private readonly DbContext context;

        public SpecialRepository(DbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Special>> GetByLocation(double latitude, string longitude)
        {
            return new List<Special>();
        }
    }
}
