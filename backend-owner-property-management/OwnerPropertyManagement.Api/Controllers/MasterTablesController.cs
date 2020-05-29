using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OwnerPropertyManagement.Domain.IDomain;

namespace OwnerPropertyManagement.Api.Controllers
{
    [Route("api/master-table")]
    [ApiController]
    public class MasterTablesController : ControllerBase
    {
        private readonly IMasterTablesDomain _masterTablesDomain;

        public MasterTablesController(IMasterTablesDomain masterTablesDomain)
        {
            _masterTablesDomain = masterTablesDomain;
        }

        [HttpGet]
        [Route("towns")]
        public async Task<IActionResult> GetTowsAsync()
        {
            var result = await _masterTablesDomain.GetTowsAsync();
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("facilities")]
        public async Task<IActionResult> GetFacilitiesAsync()
        {
            var result = await _masterTablesDomain.GetFacilitiesAsync();
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }
    }
}