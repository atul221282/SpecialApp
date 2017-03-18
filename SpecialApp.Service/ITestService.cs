using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public interface ITestService
    {
        Task<string> Test();

        Task<int> CommitAsync();
    }
}