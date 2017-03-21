using System.Collections.Generic;

namespace SpecialApp.Base
{
    public interface IBusinessException
    {
        IDictionary<string, string> GetErrors();

        void Add(string key, string error);

        void ThrowIfErrors();
    }
}