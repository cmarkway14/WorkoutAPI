using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection.Emit;

namespace DataAccess
{
    public class WorkoutDataAccess : IWorkoutDataAccess
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase db;
        private readonly string conn;

        public WorkoutDataAccess(AppConfig config)
        {
            conn = config.MongoClientConnection;
            client= new MongoClient(conn);
            db = client.GetDatabase(config.MongoDatabaseTable);
        }

        public bool DatabaseHealthCheck()
        {
            try
            {
                var healthCollection = db.GetCollection<MongoDdHealth>("Health");
                var healthResult = healthCollection.Find(Builders<MongoDdHealth>.Filter.Empty).ToList();

                if (healthResult.First().CanRead)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}