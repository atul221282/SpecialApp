using Microsoft.EntityFrameworkCore;
using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Repository
{
    public class FileDataRepository : Repository<FileData>, IFileDataRepository
    {
        private readonly DbContext context;

        public FileDataRepository(DbContext context) : base(context) { this.context = context; }

        public async Task<IQueryable<FileData>> Get()
        {
            return await Task.Factory.StartNew(() => DbSet.Where(x => x.IsDeleted == false));
        }
    }
}
