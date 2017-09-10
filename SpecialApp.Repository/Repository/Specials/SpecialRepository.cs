using Microsoft.EntityFrameworkCore;
using SpecialApp.Base;
using SpecialApp.Entity;
using SpecialApp.Entity.Specials;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Monad;
using System;

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
            var result = await DbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

            return Option.Return(() => result as ISpecial);
        }

        public async Task<Option<IEnumerable<Special>>> GetByLocation(double latitude, double longitude, int distance = 4000)
        {
            var result = await DbSet.FromSql($@" SELECT S.* FROM Special S 
                                         INNER JOIN SpecialLocation SL ON S.Id = SL.SpecialId
                                         INNER JOIN [dbo].[Location] L ON SL.LocationId = L.Id
                                         WHERE " +
            $"geography::Point(@p0, @p1, 4326).STDistance(geography::Point(@p0, @p1, 4326)) <=@p2",
            latitude, longitude, distance).GetActive().ToListAsync();

            return Option.Return(() => result.AsEnumerable());
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
