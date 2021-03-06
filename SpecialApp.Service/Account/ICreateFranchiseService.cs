﻿using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Model.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Service.Account
{
    public interface ICreateFranchiseService : IBaseService
    {
        CompanyFranchise Create(CompanyFranchise model);
    }
}
