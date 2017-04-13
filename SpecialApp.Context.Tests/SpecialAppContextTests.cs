using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SpecialApp.Entity;
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

            Assert.IsNotNull(data);
        }
    }
}
