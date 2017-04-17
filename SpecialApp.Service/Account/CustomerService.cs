using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SpecialApp.Entity.Account;
using SpecialApp.Entity.Model;
using SpecialApp.UnitOfWork;
using SpecialApp.Repository;
using SpecialApp.Context.Services;
using SpecialApp.Base;
using SpecialApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace SpecialApp.Service.Account
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly Func<IUserManagerService> serviceFunc;
        private ISpecialUOW _uow;
        private readonly IBusinessException busEx;
        private readonly Lazy<ISpecialUOW> uow;

        public ISpecialUOW Uow
        {
            get
            {
                return _uow = _uow ?? uow.Value;
            }
        }
        public CustomerService(Lazy<ISpecialUOW> uow, Func<IUserManagerService> serviceFunc,
            IBusinessException busEx) : base(uow.Value)
        {
            this.serviceFunc = serviceFunc;
            this.busEx = busEx;
            this.uow = uow;
        }
        public async Task<Users> CreateAsync(RegisterCustomer model)
        {
            IRepository<Users> repo = null;
            using (var service = serviceFunc())
            using (Uow)
            {
                var scope = await Uow.BeginTransaction();
                var result = await service.FindByEmailAsync(model.EmailAddress);

                if (result != null)
                {
                    busEx.Add("SpecialAppUsers", "User with same email address already exists");
                }

                busEx.ThrowIfErrors();

                var createdResult = await service.CreateAsync(new SpecialAppUsers
                {
                    Email = model.EmailAddress,
                    UserName = model.UserName,
                    PhoneNumber = model.PhoneNumber
                }, password: model.Password);

                var newUser = await service.FindByEmailAsync(model.EmailAddress);

                if (createdResult.Succeeded)
                {
                    repo = Uow.GetRepository<Users>();
                    repo.Add(new Users
                    {
                        AuditCreatedBy = "system",
                        AuditCreatedDate = DateTimeOffset.Now,
                        AuditLastUpdatedBy = "system",
                        AuditLastUpdatedDate = DateTimeOffset.Now,
                        DOB = model.DateOfBirth,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        SpecialAppUsersId = newUser.Id,
                        State = State.Added,
                        IsDeleted = false
                    });
                }

                await Uow.CommitAsync();

                var addedUsers = await repo.GetAll().Include(x => x.SpecialAppUsers).FirstOrDefaultAsync();

                scope.Commit();

                return addedUsers;
            }
        }
    }
}
