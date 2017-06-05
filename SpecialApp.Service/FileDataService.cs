using Microsoft.EntityFrameworkCore;
using Optional;
using SpecialApp.Entity;
using SpecialApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public class FileDataService : IFileDataService
    {
        private readonly Func<IFileDataRepository> repoFunc;

        public FileDataService(Func<IFileDataRepository> repoFunc)
        {
            this.repoFunc = repoFunc;
        }

        public async Task<Option<IEnumerable<FileData>>> Get()
        {
            var queryResult = repoFunc().Get();

            var taskResult = await queryResult;

            var result = await taskResult.ToListAsync();

            return Option.Some(result.AsEnumerable());
        }
    }
}
