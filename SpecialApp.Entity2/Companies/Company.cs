using SpecialApp.Entity.Special;
using SpecialApp.Entity2;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Companies
{
    public class Company : BaseEntity
    {
        private string _details;

        /// <summary>
        /// Gets or sets the CompanyName
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the NumberOfEmployees.
        /// </summary>
        public int? NumberOfEmployees { get; set; }

        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }

        /// <summary>
        /// Gets or sets the list of company franchise got
        /// </summary>
        public List<CompanyFranchise> CompanyFranchises { get; set; }

        /// <summary>
        /// Gets or sets the list of address company got
        /// </summary>
        public List<CompanyAddress> CompanyAddresses { get; set; }

        /// <summary>
        /// Gets or sets the list of Company followed by users
        /// </summary>
        public List<CompanyFollowedByUsers> CompanyFollowedByUsers { get; set; }
    }
}
