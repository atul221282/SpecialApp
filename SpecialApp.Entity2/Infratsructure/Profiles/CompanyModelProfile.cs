﻿using AutoMapper;
using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Model.Account;
using System;
using System.Linq;
namespace SpecialApp.Entity.Infratsructure.Profiles
{
    public class CompanyModelProfile : Profile
    {
        public CompanyModelProfile()
        {
            CreateMap<CompanyModel, Company>()
                .ForMember(d => d.AuditCreatedBy, opt => opt.ResolveUsing((cfm, cf, st, rContext) => rContext.Items["EmailAddress"]))
                .ForMember(d => d.AuditLastUpdatedBy, opt => opt.ResolveUsing((cfm, cf, st, rContext) => rContext.Items["EmailAddress"]))
                .ForMember(d => d.AuditCreatedDate, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
                .ForMember(d => d.AuditLastUpdatedDate, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
                .ForMember(x => x.Details, opt => opt.MapFrom(x => x.Details))
                .ForMember(x => x.NumberOfEmployees, opt => opt.MapFrom(x => x.NumberOfEmployees))
                .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.CompanyName))
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
                .ForMember(x => x.State, opt => opt.MapFrom(x => x.State))
                .ReverseMap()
                .ForMember(x => x.Addresses, opt => opt.MapFrom(x => x.CompanyAddresses.Select(y => y.Address)))
                .ForMember(x => x.IsDeleted, opt => opt.MapFrom(x => x.IsDeleted ?? false))
                .ForMember(x => x.ComapnyId, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.NumberOfEmployees, opt => opt.MapFrom(y => y.NumberOfEmployees ?? 0));
        }
    }
}
