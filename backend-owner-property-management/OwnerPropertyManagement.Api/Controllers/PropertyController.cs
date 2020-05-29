using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OwnerPropertyManagement.Domain.Dtos;
using OwnerPropertyManagement.Domain.Dtos.Filter;
using OwnerPropertyManagement.Domain.IServices;

namespace OwnerPropertyManagement.Api.Controllers
{
    [Route("api/property")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService ownerService)
        {
            _propertyService = ownerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(PropertyDto property)
        {
            var result = await _propertyService.AddAsync(property);
            return result != null ? (IActionResult) Ok() : Conflict();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(PropertyDto property)
        {
            var result = await _propertyService.UpdateAsync(property);
            return result != null ? (IActionResult) Ok(result) : Conflict();
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync(PropertyFilter propertyFilter)
        {
            var result = await _propertyService.GetAllAsync(propertyFilter);
            return result.Items.Any() ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _propertyService.GetByIdAsync(id);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _propertyService.DeleteAsync(id);
            return result ? (IActionResult) Ok(true) : NotFound();
        }
    }
}