using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.RulesEngine
{
    public interface IRuleStatement<T>
    {
        bool IsValid();

        T Process();
    }
}
