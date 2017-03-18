using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API
{
    public class TempService : ITempService
    {
        public string Test()
        {
            return "Test ";
        }
    }
    public interface ITempService
    {
        string Test();
    }
}
