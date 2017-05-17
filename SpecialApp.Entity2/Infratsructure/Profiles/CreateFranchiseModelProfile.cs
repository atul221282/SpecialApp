using AutoMapper;
using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Model.Account;

namespace SpecialApp.Entity.Infratsructure.Profiles
{
    public class CreateFranchiseModelProfile : Profile
    {
        public CreateFranchiseModelProfile()
        {
            CreateMap<CreateFranchiseModel, CompanyFranchise>();
        }
    }
}
