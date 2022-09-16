using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WorkoutAPI.Controllers
{
    [ApiController]
    public class HealthCheckController : Controller
    {
        [Route("api/[controller]/check")]
        [HttpGet]
        public ActionResult Health()
        {
            var mongoDBStatus = CheckMongoDbHealth();

            if (mongoDBStatus)
            {
                return Ok($"MongoDB is up as of: {DateTime.Now.ToString("MM/dd/y h:mm tt")}");
            }

            return StatusCode(400, "MongoDB is not up, you might need to go reboot it");
        }

        private bool CheckMongoDbHealth()
        {
            try
            {
                var conn = "mongodb+srv://Cmarkway14:<PASSWORD>@workoutdb.nxwwqq9.mongodb.net/?retryWrites=true&w=majority";
                var client = new MongoClient(conn);
                var workoutDB = client.GetDatabase("Workout");

                var healthCollection = workoutDB.GetCollection<MongoDdHealth>("Health");
                var healthResult = healthCollection.Find(Builders<MongoDdHealth>.Filter.Empty).ToList();

                if (healthResult.First().CanRead)
                {
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                return false;
            }

        }
    }

    public class MongoDdHealth
    {
        public ObjectId _id { get; set; }
        public bool CanRead { get; set; }
    }
}
