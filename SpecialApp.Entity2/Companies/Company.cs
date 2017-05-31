using System;
using System.Collections.Generic;

namespace SpecialApp.Entity.Companies
{
    public class Company : BaseCode, IBaseCode
    {
        private string _code;

        public string CompanyName { get; set; }

        public int? NumberOfEmployees { get; set; }

        public string Details { get; set; }

        public List<CompanyFranchise> CompanyFranchises { get; set; }

        public List<CompanyAddress> CompanyAddresses { get; set; }

        public List<CompanyFollowedBy> CompanyFollowedBy { get; set; }

        public List<CompanyUsers> CompanyUsers { get; set; }

        public new string Code
        {
            get { return this.CompanyName; }
            set { _code = CompanyName; }
        }

        private string _description;

        public new string Description
        {
            get { return Details; }
            set { _description = Details; }
        }

    }
}