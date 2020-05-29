using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OwnerPropertyManagement.Domain.Dtos;
using OwnerPropertyManagement.Domain.IServices;

namespace OwnerPropertyManagement.Api.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(OwnerDto owner)
        {
            var result = await _ownerService.AddAsync(owner);
            return result != null ? (IActionResult) Ok() : Conflict();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(OwnerDto owner)
        {
            var result = await _ownerService.UpdateAsync(owner);
            return result != null ? (IActionResult) Ok(result) : Conflict();
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _ownerService.GetAllAsync();
            return result.Any() ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _ownerService.GetByIdAsync(id);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("owner-name-list")]
        public async Task<IActionResult> OwnerNameListAsync(int id)
        {
            var result = await _ownerService.OwnerNameListAsync();
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ownerService.DeleteAsync(id);
            return result ? (IActionResult) Ok(true) : NotFound();
        }
    }
}