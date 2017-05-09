using AutoMapper;
using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Model.Account;
using System.Linq;
namespace SpecialApp.Entity.Infratsructure.Profiles
{
    public class CreateCompanyModelProfile : Profile
    {
        public CreateCompanyModelProfile()
        {
            CreateMap<CreateCompanyModel, Company>()
                .ForMember(x => x.Details, opt => opt.MapFrom(x => x.Details))
                .ForMember(x => x.NumberOfEmployees, opt => opt.MapFrom(x => x.NumberOfEmployees))
                .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.CompanyName))
                .ForMember(x => x.CompanyAddresses, opt => opt.MapFrom(x => x.Addresses
                .Select(y => new CompanyAddress
                {
                    Address = y,
                    AddressId = y.Id.HasValue ? y.Id.Value : default(int),
                    Company = new Company
                    {
                        Id = x.ComapnyId,
                        CompanyName = x.CompanyName,
                        NumberOfEmployees = x.NumberOfEmployees,
                        Details = x.Details
                    }
                })));
        }
    }
}
