using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.RulesEngine
{
    public class StopWithFuncRule<T> : IRuleStatement<T>
    {
        private readonly Func<T> func;

        public StopWithFuncRule(Func<T> func)
        {
            this.func = func;
        }

        public bool IsValid => true;

        public T Process() => func();
    }
}
