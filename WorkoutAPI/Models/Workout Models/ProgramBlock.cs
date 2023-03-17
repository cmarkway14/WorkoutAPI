using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Workout_Models
{
    public class ProgramBlock
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ProgramType ProgramType { get; set; }

        public int Duration { get; set; }

        public List<Week> Weeks { get; set; }
    }

    public class Week
    {
        public string Name { get; set; }

        public List<Workout> Workouts { get; set; }
    }

    public class Workout
    {
        public string Name { get; set; }

        public List<Exercise> Exercise { get; set; }
    }

    public class Exercise
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Sets { get; set; }

        public double Weight { get; set; }

        public Unit Unit { get; set; }
    }

    public enum Unit
    {
        Lbs,
        Kg
    }

    public enum ProgramType
    {
        PowerLifting,
        PowerBuilding,
        StrengthTraining,
        BodyBuilding,
    }
}
