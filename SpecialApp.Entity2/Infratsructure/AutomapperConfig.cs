using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Infratsructure
{
    public static class AutomapperConfig
    {
        public static IMapper RegisterMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<>
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}
