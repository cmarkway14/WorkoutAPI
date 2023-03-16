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

        [HttpGet]
        [Route("test")]
        public async Task<ActionResult> TestAction()
        {
            return Ok(Task.FromResult(true));
        }
    }
}
