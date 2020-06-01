using System.Collections.Generic;
using System.Threading.Tasks;
using OwnerPropertyManagement.Contracts.Dtos;
using OwnerPropertyManagement.Contracts.Dtos.Filter;

namespace OwnerPropertyManagement.Domain.IDomain
{
    public interface IOwnerDomain
    {
        Task<OwnerDto> AddAsync(OwnerDto owner);
        Task<OwnerDto> UpdateAsync(OwnerDto owner);
        Task<bool> DeleteAsync(int id);
        Task<PagedCollection<OwnerDto>> GetAllAsync(PagedFilter filter);
        Task<OwnerDto> GetByIdAsync(int id);
        Task<IEnumerable<SimpleDto>> OwnerNameListAsync();
    }
}
