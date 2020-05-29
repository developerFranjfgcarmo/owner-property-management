using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OwnerPropertyManagement.Data.Context;
using OwnerPropertyManagement.Data.Entities;
using OwnerPropertyManagement.Domain.Dtos;
using OwnerPropertyManagement.Domain.IDomain;
using OwnerPropertyManagement.Domain.Mapper;

namespace OwnerPropertyManagement.Domain.Domain
{
    public class OwnerDomain : DomainBase, IOwnerDomain
    {
        public OwnerDomain(IOwnerPropertyDbContext ownerPropertyDbContext) : base(ownerPropertyDbContext)
        {
        }

        public async Task<OwnerDto> AddAsync(OwnerDto owner)
        {
            var entity = await OwnerPropertyDbContext.Owners.AddAsync(owner.MapTo<Owner>());
            await SaveChangesAsync();
            return entity.Entity.MapTo<OwnerDto>();
        }

        public async Task<OwnerDto> UpdateAsync(OwnerDto owner)
        {
            var currentOwner = await GetEntityByIdAsync(owner.Id);
            var newOwner = owner.MapTo<OwnerDto>();
            OwnerPropertyDbContext.Entry(currentOwner).CurrentValues.SetValues(newOwner);
            await SaveChangesAsync();
            return newOwner.MapTo<OwnerDto>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var owner = await GetEntityByIdAsync(id);
            owner.IsDeleted = true;
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<OwnerDto>> GetAllAsync()
        {
            var result =await OwnerPropertyDbContext.Owners.AsNoTracking().ToListAsync();
            return result.MapTo<IEnumerable<OwnerDto>>();
        }

        public async Task<OwnerDto> GetByIdAsync(int id)
        {
            var owner = await GetEntityByIdAsync(id);
            return owner.MapTo<OwnerDto>();
        }

        public async Task<IEnumerable<SimpleDto>> OwnerNameListAsync()
        {
            return await OwnerPropertyDbContext.Owners.AsNoTracking()
                .Select(s => new SimpleDto {Id = s.Id, Name = $"{s.FirstName} {s.Surname}"}).ToListAsync();
        }

        private async Task<Owner> GetEntityByIdAsync(int id)
        {
            return await OwnerPropertyDbContext.Owners.FirstOrDefaultAsync(w => w.Id == id && !w.IsDeleted);
        }
    }
}