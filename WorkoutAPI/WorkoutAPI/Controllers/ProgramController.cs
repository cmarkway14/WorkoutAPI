using Microsoft.AspNetCore.Mvc;

namespace WorkoutAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ProgramController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Program()
        {
            return Ok(Task.FromResult(true));
        }
    }
}
