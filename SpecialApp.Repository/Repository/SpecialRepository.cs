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
            return await DbSet.FromSql(@"SELECT S.* Special S 
                                         INNER JOIN SpecialLocation SL ON S.Id = SL.SpecialId
                                         INNER JOIN [dbo].[Location] L ON SL.LocationId = L.Id
                                         WHERE 
                        geography::Point(L.Latitude, L.Longitude, 4326).STDistance(geography::Point(@lat, @lon, 4326)) <=4000")
                        .ToListAsync();
        }
    }
}
