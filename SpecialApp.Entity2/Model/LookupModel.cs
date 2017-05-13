using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Model
{
    public class LookupModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
