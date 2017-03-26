using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Specials
{
    public class SpecialLocation
    {
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int SpecialId { get; set; }
        public Special Special { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
