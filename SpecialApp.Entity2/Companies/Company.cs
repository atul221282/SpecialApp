using System.Collections.Generic;

namespace SpecialApp.Entity.Companies
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }

        public int? NumberOfEmployees { get; set; }

        public string Details { get; set; }

        public List<CompanyFranchise> CompanyFranchises { get; set; }

        public List<CompanyAddress> CompanyAddresses { get; set; }

        public List<CompanyFollowedBy> CompanyFollowedBy { get; set; }
    }
}