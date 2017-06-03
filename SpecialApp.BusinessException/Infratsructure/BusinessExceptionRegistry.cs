using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException.Infratsructure
{
    public class BusinessExceptionRegistry : Registry
    {
        public BusinessExceptionRegistry()
        {
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}
