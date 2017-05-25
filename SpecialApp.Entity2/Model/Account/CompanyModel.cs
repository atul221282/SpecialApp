using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Model.Account
{
    public class CompanyModel
    {
        public int? ComapnyId { get; set; }
        public string CompanyName { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Details { get; set; }
        public List<Address> Addresses { get; set; }
        public State State { get; set; }
    }
}
