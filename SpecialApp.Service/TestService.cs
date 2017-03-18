using SpecialApp.UnitOfWork;
using System;

namespace SpecialApp.Service
{
    public class TestService : ITestService
    {
        private readonly ISpecialUOW uow;

        public TestService(ISpecialUOW uow)
        {
            this.uow = uow;
        }
        public string Test()
        {
            return uow.Test();
        }
    }
}
