using System.Collections.Generic;
using System.Threading.Tasks;
using OwnerPropertyManagement.Domain.Dtos;

namespace OwnerPropertyManagement.Domain.IServices
{
    public interface IOwnerService
    {
        Task<OwnerDto> AddAsync(OwnerDto owner);
        Task<OwnerDto> UpdateAsync(OwnerDto owner);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<OwnerDto>> GetAllAsync();
        Task<OwnerDto> GetByIdAsync(int id);
    }
}
