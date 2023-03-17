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
}
