using Microsoft.EntityFrameworkCore;
using SpecialApp.Entity2;
using SpecialApp.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public class TestService : ITestService
    {
        private readonly Func<ISpecialUOW> uowFunc;

        public TestService(Func<ISpecialUOW> uowFunc)
        {
            this.uowFunc = uowFunc;
        }

        public async Task<int> CommitAsync()
        {
            return await this.uowFunc().CommitAsync();
        }

        public async Task<string>Test()
        {
            return (await uowFunc().AddressTypeRepository.GetAll().FirstOrDefaultAsync())?.Code ?? "Test no code";
        }
    }
}
