using Microsoft.AspNetCore.Mvc;

namespace TerrainApp.API.Controllers
{
    [ApiController]
    [Route("api/guest")]
    public class GuestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetGuestData()
        {
            return Ok("Guest access");
        }
    }
}
