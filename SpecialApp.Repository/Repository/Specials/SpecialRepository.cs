using Microsoft.EntityFrameworkCore;
using SpecialApp.Base;
using SpecialApp.Entity;
using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Optional;
using System.Linq;

namespace SpecialApp.Repository.Repository.Specials
{
    public class SpecialRepository : Repository<Special>, ISpecialRepository
    {
        private readonly DbContext context;

        public SpecialRepository(DbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Option<ISpecial>> GetById(int id)
        {
            return Option.Some((ISpecial)await DbSet.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IEnumerable<Special>> GetByLocation(double latitude, double longitude, int distance = 4000)
        {
            return await DbSet.FromSql($@" SELECT S.* FROM Special S 
                                         INNER JOIN SpecialLocation SL ON S.Id = SL.SpecialId
                                         INNER JOIN [dbo].[Location] L ON SL.LocationId = L.Id
                                         WHERE " +
                $".STDistance(geography::Point('{latitude}', '{longitude}', 4326)) <=4000").GetActive().ToListAsync();
        }

        public async Task<IEnumerable<Location>> GetLocation(double latitude, double longitude, int distance = 4000)
        {
            var test = await context.Set<Location>()
               .FromSql($"SELECT * from [dbo].[Location] L WHERE " +
               $"geography::Point(L.Latitude, L.Longitude, 4326).STDistance(geography::Point(@p0, @p1, 4326)) <=@p2",
               latitude, longitude, distance).GetActive().ToListAsync();

            return test;
        }
    }
}
