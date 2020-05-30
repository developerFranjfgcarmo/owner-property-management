using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OwnerPropertyManagement.Domain.Dtos;
using OwnerPropertyManagement.Domain.Dtos.Filter;
using OwnerPropertyManagement.Domain.IDomain;

namespace OwnerPropertyManagement.Api.Controllers
{
    [Route("api/property")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyDomain _propertyDomain;

        public PropertyController(IPropertyDomain ownerDomain)
        {
            _propertyDomain = ownerDomain;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(PropertyDto property)
        {
            var result = await _propertyDomain.AddAsync(property);
            return result != null ? (IActionResult) Ok() : Conflict();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(PropertyDto property)
        {
            var result = await _propertyDomain.UpdateAsync(property);
            return result != null ? (IActionResult) Ok(result) : Conflict();
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync(PropertyFilter propertyFilter)
        {
            var result = await _propertyDomain.GetAllAsync(propertyFilter);
            return result.Items.Any() ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _propertyDomain.GetByIdAsync(id);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _propertyDomain.DeleteAsync(id);
            return result ? (IActionResult) Ok(true) : NotFound();
        }
    }
}