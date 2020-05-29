using System.Linq;
using OwnerPropertyManagement.Domain.Domain;
using OwnerPropertyManagement.Domain.Dtos.Filter;
using OwnerPropertyManagement.Test.Mocks;
using Xunit;

namespace OwnerPropertyManagement.Test.Domains
{

    public class PropertyDomainTest : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public PropertyDomainTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
            PropertyMock.Instance().AddProperties(_fixture);
        }

        [Fact]
        public async void Property_Paged_from_1_to_5()
        {
            var propertyDomain = new PropertyDomain(  _fixture.GetDbContext());
            var propertyFilter = new PropertyFilter{ Page = 1,Take = 5};
            var result = await propertyDomain.GetAllAsync(propertyFilter);
            Assert.True(result.Items.FirstOrDefault()?.Id == 1);
            Assert.True(result.Total == 10);
        }
        [Fact]
        public async void Property_Paged_from_6_to_10()
        {
            var propertyDomain = new PropertyDomain( _fixture.GetDbContext());
            var propertyFilter = new PropertyFilter { Page = 2, Take = 5 };
            var result = await propertyDomain.GetAllAsync(propertyFilter);
            Assert.True(result.Items.FirstOrDefault()?.Id==6);
            Assert.True(result.Total == 10);
        }
        [Fact]
        public async void Property_Paged_from_1_to_5_with_ownerId()
        {
            var propertyDomain = new PropertyDomain(_fixture.GetDbContext());
            var propertyFilter = new PropertyFilter { Page = 1, Take = 5,OwnerId = 1};
            var result = await propertyDomain.GetAllAsync(propertyFilter);
            Assert.True(result.Items.FirstOrDefault()?.Id == 1);
            Assert.True(result.Total == 6);
        }
    }
}
