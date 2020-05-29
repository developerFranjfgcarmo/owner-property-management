using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using OwnerPropertyManagement.Data.Context;
using OwnerPropertyManagement.Data.Entities;
using OwnerPropertyManagement.Domain.Dtos;
using OwnerPropertyManagement.Domain.Dtos.Filter;
using OwnerPropertyManagement.Domain.IServices;
using OwnerPropertyManagement.Domain.Mapper;
using OwnerPropertyManagement.Domain.Queries;

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
            var newProperty = property.MapTo<Property>();
            OwnerPropertyDbContext.Entry(currentProperty).CurrentValues.SetValues(newProperty);
            await SaveChangesAsync();
            return newProperty.MapTo<PropertyDto>();
        }

        private void UpdateFacilities(IEnumerable<PropertyFacility> currentFacilities,
            IEnumerable<int> facilityIds, int propertyId)
        {
            var recordsToRemove = currentFacilities
                .Where(w => !facilityIds.Contains(w.FacilityId)).ToList();
            var recordsToAdd = facilityIds.Where(w =>
                !currentFacilities.Select(s => s.FacilityId).ToList().Contains(w));
            OwnerPropertyDbContext.PropertyFacilities.RemoveRange(recordsToRemove);
            OwnerPropertyDbContext.PropertyFacilities.AddRange(recordsToAdd.Select(s => new PropertyFacility
            { PropertyId = propertyId, FacilityId = s }));
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var property = await GetEntityByIdAsync(id);
            property.IsDeleted = true;
            return await SaveChangesAsync();
        }

        public async Task<PagedCollection<PropertyListDto>> GetAllAsync(PropertyFilter propertyFilter)
        {
            var where = string.Empty;
            if (propertyFilter.OwnerId.HasValue)
            {
                where = PropertyQuery.GetAllWhere;
            }

            var query = string.Format(PropertyQuery.GetAll, where);
            await OwnerPropertyDbContext.Database.GetDbConnection().QueryMultipleAsync(query);
            var result = new PagedCollection<PropertyListDto>();
            using var reader = await OwnerPropertyDbContext.Database.GetDbConnection().QueryMultipleAsync(query, propertyFilter);
            result.Items = (await reader.ReadAsync<PropertyListDto>()).ToList();
            result.Total = (await reader.ReadAsync<int>()).FirstOrDefault();
            return result;
        }

        public async Task<PropertyDto> GetByIdAsync(int id)
        {
            var property = (await GetEntityByIdAsync(id));
            return property.MapTo<PropertyDto>();
        }
        private async Task<Property> GetEntityByIdAsync(int id)
        {
            return await OwnerPropertyDbContext.Properties.Include(i=>i.PropertyFacilities).FirstOrDefaultAsync(w => w.Id == id && !w.IsDeleted);
        }
    }
}
