using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection.Emit;
using Models.DataAccessObjects;
using Models.Workout_Models;

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

        public async Task<ProgramBlockDAO> GetPrograms()
        {
            try
            {
                var workoutCollection = db.GetCollection<ProgramBlockDAO>("Workouts");
                var workoutResult = await workoutCollection.FindAsync(Builders<ProgramBlockDAO>.Filter.Empty);

                return new ProgramBlockDAO();


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> InsertProgram(ProgramBlock block)
        {
            try
            {
                var workoutCollection = db.GetCollection<ProgramBlock>("Workouts");
                await workoutCollection.InsertOneAsync(block);

                return true;


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}