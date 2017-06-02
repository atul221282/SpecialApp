using SpecialApp.Base.Rules.QueryableSearchFilter;
using System.Collections.Generic;
using Xunit;
using SpecialApp.Entity;
using System;
using System.Linq;

namespace SpecialApp.Base.Test
{
    public class TestQueryableFilterTest
    {
        public TestQueryableFilterTest()
        {

        }

        [Fact]
        public void TestSearchFilters()
        {
            var orgList = (new List<AddressType>
            {
                new AddressType{Id=1,Code="1C", Description="1D" },
                new AddressType{Id=2,Code="2C", Description="2D" },
                new AddressType{Id=3,Code="3C", Description="3D" },
                new AddressType{Id=4,Code="4C", Description="4D" },
                new AddressType{Id=11,Code="11C", Description="11D" },
                new AddressType{Id=12,Code="12C", Description="12D" }
            }).AsEnumerable();

            var list = orgList;

            var testFilters = new PermitSearchFlterFactory<AddressType>(list);

            string code = "", description = "1";
            int id = 1;

            testFilters.AddFilter(
                FilterFactory.CreateFilterWithFunc(
                        () => description.IsNotNullOrWhiteSpace(),
                        () => list = list.Where(x => x.Description.StartsWith("4")
                        && x.Description.IsNotNullOrWhiteSpace())
                )).AddFilter(FilterFactory.CreateNullOrDefault<int>(
                        id,
                        () => list = list.Where(x => x.Id == id)
                ));

            testFilters.RunFilters();

            Assert.True(orgList.Count() != list.Count());
        }
    }
}
