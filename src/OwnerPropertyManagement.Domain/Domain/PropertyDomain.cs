﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using OwnerPropertyManagement.Contracts.Dtos;
using OwnerPropertyManagement.Contracts.Dtos.Filter;
using OwnerPropertyManagement.Contracts.Mapper;
using OwnerPropertyManagement.Data.Context;
using OwnerPropertyManagement.Data.Entities;
using OwnerPropertyManagement.Domain.IDomain;
using OwnerPropertyManagement.Domain.Queries;

namespace OwnerPropertyManagement.Domain.Domain
{
    public class PropertyDomain: DomainBase, IPropertyDomain
    {
        public PropertyDomain(IOwnerPropertyDbContext ownerPropertyDbContext) : base(ownerPropertyDbContext)
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
            var result = new PagedCollection<PropertyListDto>();
            using var reader = await OwnerPropertyDbContext.Database.GetDbConnection().QueryMultipleAsync(query, propertyFilter);
            result.Items = (await reader.ReadAsync<PropertyListDto>()).ToList();
            result.Total=  reader.ReadFirstOrDefault<long>();
            return result;
        }

        public async Task<PropertyDto> GetByIdAsync(int id)
        {
            var property = (await GetEntityByIdAsync(id));
            return property.MapTo<PropertyDto>();
        }

        public async Task<bool> HasPropertiesAsync(int ownerId)
        {
           return await OwnerPropertyDbContext.Properties.AnyAsync(c => c.OwnerId == ownerId && !c.IsDeleted);
        }

        private async Task<Property> GetEntityByIdAsync(int id)
        {
            return await OwnerPropertyDbContext.Properties.Include(i=>i.PropertyFacilities).FirstOrDefaultAsync(w => w.Id == id && !w.IsDeleted);
        }
    }
}
