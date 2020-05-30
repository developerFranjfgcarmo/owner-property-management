﻿using System.Collections.Generic;
using System.Threading.Tasks;
using OwnerPropertyManagement.Domain.Dtos;

namespace OwnerPropertyManagement.Domain.IDomain
{
    public interface IOwnerDomain
    {
        Task<OwnerDto> AddAsync(OwnerDto owner);
        Task<OwnerDto> UpdateAsync(OwnerDto owner);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<OwnerDto>> GetAllAsync();
        Task<OwnerDto> GetByIdAsync(int id);
        Task<IEnumerable<SimpleDto>> OwnerNameListAsync();
    }
}