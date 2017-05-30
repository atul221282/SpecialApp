using System.Threading.Tasks;
using SpecialApp.Service;

namespace SpecialApp.API.Filters
{
    public interface ISecurityAdminPermissionService : IBaseService
    {
        Task<int> GetPermission(string userId, string screen, string action);
    }
}