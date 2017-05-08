using AutoMapper;
using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Model.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Infratsructure.Profiles
{
    public class CreateCompanyModelProfile : Profile
    {
        public CreateCompanyModelProfile()
        {
            CreateMap<CreateCompanyModel, Company>()
                .ForMember(x => x.Details, opt => opt.MapFrom(x => x.Details))
                .ForMember(x => x.NumberOfEmployees, opt => opt.MapFrom(x => x.NumberOfEmployees))
                .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.CompanyName));
            
        }
    }
}
