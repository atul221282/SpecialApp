using Microsoft.EntityFrameworkCore;
using SpecialApp.Entity;
using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public class BaseCodeService : BaseService, IBaseCodeService
    {
        public BaseCodeService(ISpecialUOW uow) : base(uow)
        {

        }

        public async Task<IEnumerable<T>> Get<T>() where T : BaseCode
        {
            var result = await _uow.GetRepository<T>()
                .GetAll()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return result;
        }
    }
}
