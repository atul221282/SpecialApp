using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Service
{
    public abstract class BaseService : IBaseService
    {
        private IBaseUOW _uow;
        private readonly Func<IBaseUOW> uow;

        public IBaseUOW Uow
        {
            get
            {
                return _uow = _uow ?? uow();
            }
        }

        protected BaseService(Func<IBaseUOW> uow)
        {
            this.uow = uow;
        }

        public void Dispose()
        {
            Uow.Dispose();
        }
    }
}
