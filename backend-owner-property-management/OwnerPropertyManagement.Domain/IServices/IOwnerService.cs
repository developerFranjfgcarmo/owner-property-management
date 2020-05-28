using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OwnerPropertyManagement.Domain.Dtos;

namespace OwnerPropertyManagement.Domain.IServices
{
    public interface IOwnerService
    {
        Task<OwnerDto> AddAsync(OwnerDto property);
        Task<OwnerDto> UpdateAsync(OwnerDto property);
        Task<bool> DeleteAsync(OwnerDto property);
        Task<OwnerDto> GetPropertiesByOIdAsync(int id);
        Task<IEnumerable<OwnerDto>> GetAllAsync(int id);
    }
}
