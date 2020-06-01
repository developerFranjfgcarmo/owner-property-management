using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OwnerPropertyManagement.Domain.Domain;
using OwnerPropertyManagement.Domain.Dtos.Filter;
using OwnerPropertyManagement.Test.Mocks;
using Xunit;

namespace OwnerPropertyManagement.Test.Services
{
    public class OwnerServiceTest : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public OwnerServiceTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
            OwnerMock.Instance().AddOwners(_fixture);
        }
        [Fact]
        public async void Owners_Paged_from_1_to_5()
        {
            var ownerDomain = new OwnerDomain(_fixture.GetDbContext());
            var filter = new PagedFilter{ Page = 1, Take = 5 };
            var result = await ownerDomain.GetAllAsync(filter);
            Assert.True(result.Items.FirstOrDefault()?.Id == 1);
            Assert.True(result.Total == 10);
        }
        [Fact]
        public async void Owners_Paged_from_6_to_10()
        {
            var ownerDomain = new OwnerDomain(_fixture.GetDbContext());
            var filter = new PagedFilter { Page = 2, Take = 5 };
            var result = await ownerDomain.GetAllAsync(filter);
            Assert.True(result.Items.FirstOrDefault()?.Id == 6);
            Assert.True(result.Total == 10);
        }
    }
}
