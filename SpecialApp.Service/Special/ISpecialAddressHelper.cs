using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SP = SpecialApp.Entity.Specials;

namespace SpecialApp.Service.Special
{
    public interface ISpecialAddressHelper
    {
        Task<ISpecialAddressHelper> WithAddress();

        IEnumerable<SP.ISpecial> Resolve();
    }
}
