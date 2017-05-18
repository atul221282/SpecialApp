﻿using AutoMapper;
using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Model.Account;
using System;
using System.Linq;

namespace SpecialApp.Entity.Infratsructure.Profiles
{
    public class CreateFranchiseModelProfile : Profile
    {
        public CreateFranchiseModelProfile()
        {
            CreateMap<CreateFranchiseModel, CompanyFranchise>()
                
                .ForMember(x => x.CompanyFranchiseAddresses, opt => opt.MapFrom(c => c.Addresses
                .Select(y => new CompanyFranchiseAddress
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
                    CompanyFranchise = new CompanyFranchise { Id = c.Id },
                    CompanyFranchiseId = c.Id
                })));
        }
    }
}
