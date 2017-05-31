﻿using Microsoft.EntityFrameworkCore;
using SpecialApp.Entity;
using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Model;
using SpecialApp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Service
{
    public class BaseCodeService : BaseService, IBaseCodeService
    {
        private readonly Dictionary<string, Func<Task<IEnumerable<IBaseCode>>>> BaseCodeTables =
            new Dictionary<string, Func<Task<IEnumerable<IBaseCode>>>>();

        public BaseCodeService(ISpecialUOW uow) : base(uow)
        {
            this.BaseCodeTables.Add("AddressType", Get<AddressType>);
            this.BaseCodeTables.Add("CompanyFranchiseCategory", Get<CompanyFranchiseCategory>);
            this.BaseCodeTables.Add("Country", Get<Country>);
            this.BaseCodeTables.Add("Company", Get<Company>);
        }

        public async Task<IEnumerable<IBaseCode>> GetByDictionary(string key)
        {
            var result = (await BaseCodeTables[key].Invoke());
            return result;
        }

        private async Task<IEnumerable<IBaseCode>> Get<T>() where T : BaseCode
        {
            var result = await _uow.GetRepository<T>()
                .GetAll()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return result;
        }
    }
}
