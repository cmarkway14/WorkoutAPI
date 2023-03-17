using Models.DataAccessObjects;
using Models.Workout_Models;

namespace DataAccess
{
    public interface IWorkoutDataAccess
    {
        bool DatabaseHealthCheck();

        Task<ProgramBlockDAO> GetPrograms();

        Task<bool> InsertProgram(ProgramBlock block);
    }
}