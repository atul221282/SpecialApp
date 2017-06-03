using System.Collections.Generic;

namespace SpecialApp.BusinessException
{
    public interface IAddBusinessError
    {
        KeyValuePair<string, string> errorMessage { get; }
    }
}