using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OwnerPropertyManagement.Data.Context;
using OwnerPropertyManagement.Data.Entities;
using OwnerPropertyManagement.Domain.Dtos;
using OwnerPropertyManagement.Domain.IServices;
using OwnerPropertyManagement.Domain.Mapper;

namespace OwnerPropertyManagement.Domain.Services
{
    public class PropertyService: ServiceBase, IPropertyService
    {
        public PropertyService(IOwnerPropertyDbContext ownerPropertyDbContext) : base(ownerPropertyDbContext)
        {
        }
        public async Task<PropertyDto> AddAsync(PropertyDto property)
        {
            var entity = await OwnerPropertyDbContext.Properties.AddAsync(property.MapTo<Property>());
            await SaveChangesAsync();
            return entity.Entity.MapTo<PropertyDto>();
        }

        public async Task<PropertyDto> UpdateAsync(PropertyDto property)
        {
            var currentProperty = await GetEntityByIdAsync(property.Id);
            var newProperty = property.MapTo<PropertyDto>();
            OwnerPropertyDbContext.Entry(currentProperty).CurrentValues.SetValues(newProperty);
            await SaveChangesAsync();
            return newProperty.MapTo<PropertyDto>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var property = await GetEntityByIdAsync(id);
            property.IsDeleted = true;
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<PropertyDto>> GetAllAsync(int? ownerId)
        {
            //paged
            throw new NotImplementedException();
        }

        public async Task<PropertyDto> GetByIdAsync(int id)
        {
            var property = await GetEntityByIdAsync(id);
            return property.MapTo<PropertyDto>();
        }
        private async Task<Property> GetEntityByIdAsync(int id)
        {
            return await OwnerPropertyDbContext.Properties.FirstOrDefaultAsync(w => w.Id == id && !w.IsDeleted);
        }
    }
}
