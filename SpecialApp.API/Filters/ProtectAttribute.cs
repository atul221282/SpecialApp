using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.API.Filters
{
    public class ProtectAttribute : TypeFilterAttribute
    {
        public ProtectAttribute(string screen, string action, short level)
        : base(typeof(ProtectActionFilter))
        {
            Arguments = new object[] { screen, action, level };
        }

        public ProtectAttribute(string[] screens, string[] actions, short level)
        : base(typeof(ProtectWithMultipleActionFilter))
        {
            Arguments = new object[] { screens, actions, level };
        }
    }
}
