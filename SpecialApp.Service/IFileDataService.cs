using Optional;
using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public interface IFileDataService
    {
        Task<Option<IEnumerable<FileData>>> Get();
    }
}
