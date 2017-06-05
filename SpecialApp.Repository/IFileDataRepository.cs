using SpecialApp.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.Repository
{
    public interface IFileDataRepository
    {
        Task<IQueryable<FileData>> Get();
    }
}