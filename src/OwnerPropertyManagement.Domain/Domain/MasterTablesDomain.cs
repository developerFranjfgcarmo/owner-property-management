using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OwnerPropertyManagement.Contracts.Dtos;
using OwnerPropertyManagement.Contracts.Mapper;
using OwnerPropertyManagement.Data.Context;
using OwnerPropertyManagement.Domain.IDomain;

namespace OwnerPropertyManagement.Domain.Domain
{
    public class MasterTablesDomain : DomainBase, IMasterTablesDomain
    {
        public MasterTablesDomain(IOwnerPropertyDbContext ownerPropertyDbContext) : base(ownerPropertyDbContext)
        {
        }

        public async Task<IEnumerable<SimpleDto>> GetTowsAsync()
        {
            var result = await OwnerPropertyDbContext.Towns.AsNoTracking().ToListAsync();
            return result.MapTo<IEnumerable<SimpleDto>>();
        }

        public async Task<IEnumerable<SimpleDto>> GetFacilitiesAsync()
        {
            var result = await OwnerPropertyDbContext.Facilities.AsNoTracking().ToListAsync();
            return result.MapTo<IEnumerable<SimpleDto>>();
        }
    }
}