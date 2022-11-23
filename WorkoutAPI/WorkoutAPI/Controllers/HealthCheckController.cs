using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;

namespace WorkoutAPI.Controllers
{
    [ApiController]
    public class HealthCheckController : Controller
    {
        private readonly IWorkoutDataAccess _workoutDataAccess;
        private readonly IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions;

        public HealthCheckController(IWorkoutDataAccess workoutDataAccess, IMemoryCache cache)
        {
            _workoutDataAccess = workoutDataAccess;
            _cache = cache;
            _cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
        }

        [Route("api/[controller]/check")]
        [HttpGet]
        public ActionResult Health()
        {
            bool mongoDBStatus;
            try
            {
                if(!_cache.TryGetValue("mongoDBStatus", out mongoDBStatus))
                {
                    mongoDBStatus = _workoutDataAccess.DatabaseHealthCheck();

                    _cache.Set("mongoDBStatus", mongoDBStatus, _cacheEntryOptions);
                }

                if (mongoDBStatus)
                {
                    return Ok($"MongoDB is up as of: {DateTime.Now.ToString("MM/dd/y h:mm tt")}");
                }

                return StatusCode(400, "MongoDB is not up, you might need to go reboot it");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error Occured: {ex}");
            }



        }
    }
}
