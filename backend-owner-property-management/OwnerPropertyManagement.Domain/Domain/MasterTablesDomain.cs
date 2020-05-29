using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OwnerPropertyManagement.Data.Context;
using OwnerPropertyManagement.Domain.Dtos;
using OwnerPropertyManagement.Domain.IDomain;
using OwnerPropertyManagement.Domain.Mapper;

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