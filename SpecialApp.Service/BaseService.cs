using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Service
{
    public abstract class BaseService : IBaseService
    {
        private IBaseUOW uow;

        protected BaseService(IBaseUOW uow)
        {
            this.uow = uow;
        }

        public void Dispose()
        {
            Uow.Dispose();
        }
    }
}
