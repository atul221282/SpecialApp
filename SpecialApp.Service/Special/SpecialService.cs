using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpecialApp.Repository.Repository;

namespace SpecialApp.Service.Special
{
    public class SpecialService : ISpecialService
    {
        private readonly Func<ISpecialRepository> repoFunc;

        public SpecialService(Func<ISpecialRepository> repoFunc)
        {
            this.repoFunc = repoFunc;
        }
        public async Task<IEnumerable<Entity.Specials.Special>> GetByLocation(double latitude, string longitude)
        {
            var repo = repoFunc();
            return await repo.GetByLocation(latitude, longitude);
        }
    }
}
