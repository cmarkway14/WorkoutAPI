﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Workout_Models;

namespace Models.interfaces
{
    public interface IProgramService
    {
        Task<ProgramBlock> GetPrograms();

        Task<bool> InsertProgram(ProgramBlock block);
    }
}
