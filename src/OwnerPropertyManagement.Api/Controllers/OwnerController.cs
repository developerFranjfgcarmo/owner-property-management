﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OwnerPropertyManagement.Contracts.Dtos;
using OwnerPropertyManagement.Contracts.Dtos.Filter;
using OwnerPropertyManagement.Domain.IDomain;

namespace OwnerPropertyManagement.Api.Controllers
{
    [Route("api/owner")]
    [ApiController]
    [Authorize]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerDomain _ownerDomain;
        private readonly IPropertyDomain _propertyDomain;

        public OwnerController(IOwnerDomain ownerDomain, IPropertyDomain propertyDomain)
        {
            _ownerDomain = ownerDomain;
            _propertyDomain = propertyDomain;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(OwnerDto owner)
        {
            var result = await _ownerDomain.AddAsync(owner);
            return result != null ? (IActionResult) Ok() : Conflict();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(OwnerDto owner)
        {
            var result = await _ownerDomain.UpdateAsync(owner);
            return result != null ? (IActionResult) Ok(result) : Conflict();
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] PagedFilter filter)
        {
            var result = await _ownerDomain.GetAllAsync(filter);
            return result.Items.Any() ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _ownerDomain.GetByIdAsync(id);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("owner-name-list")]
        public async Task<IActionResult> OwnerNameListAsync()
        {
            var result = await _ownerDomain.OwnerNameListAsync();
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (await _propertyDomain.HasPropertiesAsync(id)) return Conflict("Owner has active properties.");
            var result = await _ownerDomain.DeleteAsync(id);
            return result ? (IActionResult) Ok(true) : NotFound();
        }
    }
}