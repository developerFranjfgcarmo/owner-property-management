using System.Collections.Generic;
using System.Threading.Tasks;
using OwnerPropertyManagement.Domain.Dtos;

namespace OwnerPropertyManagement.Domain.IServices
{
    public interface IPropertyService
    {
        Task<PropertyDto> AddAsync(PropertyDto property);
        Task<PropertyDto> UpdateAsync(PropertyDto property);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PropertyDto>> GetAllAsync(int? ownerId);
        Task<PropertyDto> GetByIdAsync(int id);
    }
}
