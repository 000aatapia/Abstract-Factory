using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvisioningController : ControllerBase
    {
        private readonly IProvisioningService _provisioningService;

        public ProvisioningController(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        /// <summary>
        /// Endpoint unificado para aprovisionar máquinas virtuales multi-cloud.
        /// </summary>
        [HttpPost("provision")]
        public async Task<IActionResult> ProvisionResources([FromBody] ProvisioningRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _provisioningService.ProvisionResourcesAsync(request);
            return Ok(result);
        }
    }
}
