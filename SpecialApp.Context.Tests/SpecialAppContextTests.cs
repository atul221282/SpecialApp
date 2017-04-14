using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SpecialApp.Entity;
using SpecialApp.Entity.Account;
using SpecialApp.Entity.Options;
using System.Linq;

namespace SpecialApp.Context.Tests
{
    [TestClass]
    public class SpecialAppContextTests
    {
        SpecialContext context;
        IOptions<ConnectionStringsOptions> options;

        [TestInitialize]
        public void Initialize()
        {
            options = Substitute.For<IOptions<ConnectionStringsOptions>>();
            options.Value.Returns(new ConnectionStringsOptions
            {
                DefaultConnection = "Server = (localdb)\\MSSQLLocalDB; Database = SpecialApp; Trusted_Connection = True; "
            });
            context = new SpecialContext(options);
        }

        [TestMethod]
        public void AddUsersTests()
        {
            var data = context.Users.ToList();
            
            var user = new Users
            {
                AuditCreatedBy = "system",
                AuditCreatedDate = System.DateTimeOffset.Now,
                AuditLastUpdatedBy = "system",
                AuditLastUpdatedDate = System.DateTimeOffset.Now,
                DOB = System.DateTimeOffset.Now.AddYears(33),
                FirstName = "Atul",
                LastName = "Chaudhary",
                State = State.Added,
                SpecialAppUsersId = "348ddfe1-753b-43e3-8b20-670e8240aa44",
                IsDeleted = false,
            };

            var user2 = new Users
            {
                AuditCreatedBy = "system",
                AuditCreatedDate = System.DateTimeOffset.Now,
                AuditLastUpdatedBy = "system",
                AuditLastUpdatedDate = System.DateTimeOffset.Now,
                DOB = System.DateTimeOffset.Now.AddYears(33),
                FirstName = "Bhanu",
                LastName = "Sharma",
                State = State.Added,
                SpecialAppUsersId = "348ddfe1-753b-43e3-8b20-670e8240aa44",
                IsDeleted = false,
            };

            var allUsers = context.Set<SpecialAppUsers>().ToList();

            //context.Users.Add(user);
            //context.SaveChanges();

            //context.Users.Add(user2);
            //context.SaveChanges();

            Assert.IsNotNull(allUsers);
        }

        private class DateTimeOffeset
        {
        }
    }
}
