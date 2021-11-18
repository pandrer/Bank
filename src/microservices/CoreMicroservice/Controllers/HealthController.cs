using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        public HealthController()
        {
        }


        [HttpGet("ping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Ping()
        {
            return Ok("OK");
        }

    }
}
