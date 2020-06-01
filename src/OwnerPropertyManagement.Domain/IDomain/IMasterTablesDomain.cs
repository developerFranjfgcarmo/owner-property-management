using System.Collections.Generic;
using System.Threading.Tasks;
using OwnerPropertyManagement.Contracts.Dtos;

namespace OwnerPropertyManagement.Domain.IDomain
{
    public interface IMasterTablesDomain
    {
        Task<IEnumerable<SimpleDto>> GetTowsAsync();
        Task<IEnumerable<SimpleDto>> GetFacilitiesAsync();
    }
}