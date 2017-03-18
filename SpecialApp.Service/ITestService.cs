using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public interface ITestService
    {
        string Test();

        Task<int> CommitAsync();
    }
}