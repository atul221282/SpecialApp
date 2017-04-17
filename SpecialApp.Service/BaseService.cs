using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Service
{
    public abstract class BaseService : IBaseService
    {
        private IBaseUOW _uow;
        
        protected BaseService(IBaseUOW uow)
        {
            this._uow = uow;
        }

        public void Dispose()
        {
            _uow?.Dispose();
        }
    }
}
