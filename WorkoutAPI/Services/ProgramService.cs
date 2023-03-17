using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models.interfaces;
using Models.Workout_Models;

namespace Services
{
    public class ProgramService : IProgramService
    {
        private readonly IWorkoutDataAccess _workoutDataAccess;

        public ProgramService(IWorkoutDataAccess workoutDataAccess)
        {
            _workoutDataAccess = workoutDataAccess;
        }


        public async Task<ProgramBlock> GetPrograms()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertProgram(ProgramBlock block)
        {
            await _workoutDataAccess.InsertProgram(block);

            return true;
        }
    }
}
