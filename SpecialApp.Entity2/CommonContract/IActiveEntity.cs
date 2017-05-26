using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.CommonContract
{
    public interface IActiveEntity
    {
        bool? IsDeleted { get; set; }
    }
}
