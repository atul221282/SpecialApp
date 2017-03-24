using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Specials
{
    public class SpecialAddress
    {
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int SpecialId { get; set; }
        public virtual Special Special { get; set; }


        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
    }
}
