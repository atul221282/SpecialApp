using System.Collections.Generic;

namespace SpecialApp.BusinessException
{
    public interface IPropertyValidator
    {
        KeyValuePair<string, string> errorMessage
        {
            get;
        }

        bool Execute();
    }
}