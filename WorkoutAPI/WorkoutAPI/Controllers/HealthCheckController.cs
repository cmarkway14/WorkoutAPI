using Microsoft.AspNetCore.Mvc;

namespace WorkoutAPI.Controllers
{
    [ApiController]
    public class HealthCheckController : Controller
    {
        [Route("api/[controller]/check")]
        public ActionResult Health()
        {
            return Ok(DateTime.Now.ToString("MM/dd/y h:mm tt"));
        }
    }
}
