using SpecialApp.UnitOfWork;
using System;

namespace SpecialApp.Service
{
    public class TestService : ITestService
    {
        private readonly Func<ISpecialUOW> uowFunc;

        public TestService(Func<ISpecialUOW> uowFunc)
        {
            this.uowFunc = uowFunc;
        }
        public string Test()
        {
            return uowFunc().Test();
        }
    }
}
