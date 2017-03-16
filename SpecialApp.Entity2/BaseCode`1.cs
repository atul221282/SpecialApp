using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity2
{
    public abstract class BaseCode<T> : BaseEntity<T>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
