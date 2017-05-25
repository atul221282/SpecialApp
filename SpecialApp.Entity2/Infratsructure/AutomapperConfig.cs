using AutoMapper;
using SpecialApp.Entity.Infratsructure.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Infratsructure
{
    public static class AutomapperConfig
    {
        public static IMapper RegisterMapping()
        {
            Mapper.Initialize((cfg) =>
            {
                cfg.AddProfile<CompanyModelProfile>();
                cfg.AddProfile<FranchiseModelProfile>();
            });
            
            return Mapper.Configuration.CreateMapper();
        }
    }
}
