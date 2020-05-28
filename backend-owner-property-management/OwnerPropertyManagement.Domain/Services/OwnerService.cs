using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OwnerPropertyManagement.Domain.Dtos;
using OwnerPropertyManagement.Domain.IServices;

namespace OwnerPropertyManagement.Domain.Services
{
    public class OwnerService: IOwnerService
    {
        public Task<OwnerDto> AddAsync(OwnerDto property)
        {
            throw new NotImplementedException();
        }

        public Task<OwnerDto> UpdateAsync(OwnerDto property)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(OwnerDto property)
        {
            throw new NotImplementedException();
        }

        public Task<OwnerDto> GetPropertiesByOIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OwnerDto>> GetAllAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
