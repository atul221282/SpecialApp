using SpecialApp.Context2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialApp.UnitOfWork
{
    public class SpecialUOW : ISpecialUOW
    {
        private readonly Func<SpecialContext> context;

        public SpecialUOW(Func<SpecialContext> context)
        {
            this.context = context;
        }
        public string Test()
        {
            return "Test ";
        }
    }
}
