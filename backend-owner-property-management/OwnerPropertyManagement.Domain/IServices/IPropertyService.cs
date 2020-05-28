using System.Collections.Generic;
using System.Threading.Tasks;
using OwnerPropertyManagement.Domain.Dtos;

namespace OwnerPropertyManagement.Domain.IServices
{
    public interface IPropertyService
    {
        Task<PropertyDto> AddAsync(PropertyDto property);
        Task<PropertyDto> UpdateAsync(PropertyDto property);
        Task<bool> DeleteAsync(PropertyDto property);
        Task<IEnumerable<PropertyDto>> GetPropertiesByOwnerAsync(int ownerId);
        Task<PropertyDto> GetPropertiesByOIdAsync(int id);
    }
}
