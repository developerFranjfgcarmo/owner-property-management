using System.Collections.Generic;
using System.Threading.Tasks;
using OwnerPropertyManagement.Domain.Dtos;
using OwnerPropertyManagement.Domain.Dtos.Filter;

namespace OwnerPropertyManagement.Domain.IServices
{
    public interface IPropertyService
    {
        Task<PropertyDto> AddAsync(PropertyDto property);
        Task<PropertyDto> UpdateAsync(PropertyDto property);
        Task<bool> DeleteAsync(int id);
        Task<PagedCollection<PropertyListDto>> GetAllAsync(PropertyFilter propertyFilter);
        Task<PropertyDto> GetByIdAsync(int id);
    }
}
