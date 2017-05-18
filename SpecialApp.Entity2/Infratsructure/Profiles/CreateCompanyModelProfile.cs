using AutoMapper;
using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Model.Account;
using System;
using System.Linq;
namespace SpecialApp.Entity.Infratsructure.Profiles
{
    public class CreateCompanyModelProfile : Profile
    {
        public CreateCompanyModelProfile()
        {
            CreateMap<CreateCompanyModel, Company>()
                .ForMember(d => d.AuditCreatedBy, opt => opt.ResolveUsing((cfm, cf, st, rContext) => rContext.Items["EmailAddress"]))
                .ForMember(d => d.AuditLastUpdatedBy, opt => opt.ResolveUsing((cfm, cf, st, rContext) => rContext.Items["EmailAddress"]))
                .ForMember(d => d.AuditCreatedDate, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
                .ForMember(d => d.AuditLastUpdatedDate, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
                .ForMember(x => x.Details, opt => opt.MapFrom(x => x.Details))
                .ForMember(x => x.NumberOfEmployees, opt => opt.MapFrom(x => x.NumberOfEmployees))
                .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.CompanyName))
                .ForMember(x => x.AuditLastUpdatedDate, opt => opt.ResolveUsing((y) =>
                {
                    return DateTimeOffset.UtcNow;
                }))
                .ForMember(x => x.AuditCreatedDate, opt => opt.ResolveUsing((y) =>
                {
                    return DateTimeOffset.UtcNow;
                }))
                .ForMember(x => x.IsDeleted, opt => opt.ResolveUsing((y) =>
                {
                    return false;
                }))
                .ForMember(x => x.CompanyAddresses, opt => opt.MapFrom(x => x.Addresses
                .Select(y => new CompanyAddress
                {
                    Address = new Address
                    {
                        AuditLastUpdatedBy = string.IsNullOrWhiteSpace(y.AuditLastUpdatedBy) ? "system" : y.AuditLastUpdatedBy,
                        AuditCreatedBy = string.IsNullOrWhiteSpace(y.AuditCreatedBy) ? "system" : y.AuditCreatedBy,
                        AuditCreatedDate = y.AuditCreatedDate.HasValue ? y.AuditCreatedDate : DateTimeOffset.UtcNow,
                        AuditLastUpdatedDate = y.AuditLastUpdatedDate.HasValue ? y.AuditLastUpdatedDate : DateTimeOffset.UtcNow,
                        State = y.Id.HasValue ? State.Modified : State.Added,
                        AddressState = y.AddressState,
                        PostalCode = y.PostalCode,
                        AddressTypeId = y.AddressTypeId,
                        CountryId = y.CountryId,
                        IsDeleted = false
                    },
                    AddressId = y.Id.HasValue ? y.Id.Value : default(int),
                    CompanyId = x.ComapnyId.HasValue ? x.ComapnyId.Value : default(int)
                })))
                .ForMember(x => x.State, opt => opt.MapFrom(x => x.State));
        }
    }
}
