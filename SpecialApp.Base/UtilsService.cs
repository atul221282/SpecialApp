using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base
{
    public class UtilsService : IUtilsService
    {
        public UtilsService()
        {
        }


        public ITrueFalseService ResolveBool()
        {
            return new TrueFalseService();
        }
    }
}
