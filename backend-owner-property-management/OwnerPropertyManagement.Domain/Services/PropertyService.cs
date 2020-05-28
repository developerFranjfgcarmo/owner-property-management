using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OwnerPropertyManagement.Domain.Dtos;
using OwnerPropertyManagement.Domain.IServices;

namespace OwnerPropertyManagement.Domain.Services
{
    public class PropertyService:IPropertyService
    {
        public Task<PropertyDto> AddAsync(PropertyDto property)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyDto> UpdateAsync(PropertyDto property)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(PropertyDto property)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PropertyDto>> GetPropertiesByOwnerAsync(int ownerId)
        {
            throw new NotImplementedException();
        }

        public Task<PropertyDto> GetPropertiesByOIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
