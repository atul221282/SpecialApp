using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Specials
{
    public class SpecialFile
    {
        public int SpecialId { get; set; }
        public virtual Special Special { get; set; }
        public int FileDataId { get; set; }
        public virtual FileData FileData { get; set; }
    }
}
