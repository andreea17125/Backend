using Microsoft.AspNetCore.Mvc;

namespace TerrainApp.API.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [AuthorizeAdmin]
    public class AdminController : ControllerBase
    {
        [HttpGet]
       
        public IActionResult GetAdminData()
        {
            return Ok("Admin access");
        }
    }

}
