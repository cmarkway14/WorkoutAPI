using Microsoft.AspNetCore.Mvc;
using Models.interfaces;
using Models.Workout_Models;
using System.Xml.Linq;

namespace WorkoutAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ProgramController : Controller
    {
        private readonly IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet]
        public async Task<ActionResult> Program()
        {
            return Ok(Task.FromResult(true));
        }

        [HttpGet]
        [Route("test")]
        public async Task<ActionResult> TestAction()
        {
            return Ok(Task.FromResult(true));
        }

        [HttpPost]
        public async Task<ActionResult> Insert()
        {

            var request = new ProgramBlock
            {
                Description = "Cool ass program description",
                Duration = 16,
                Name = "Cool as program",
                ProgramType = ProgramType.PowerLifting,
                Weeks = new List<Week>
                {
                    new Week
                    {
                        Name = "week 1",
                        Workouts = new List<Workout>
                        {
                            new Workout
                            {
                                Name = "Day 1",
                                Exercise = new List<Exercise>
                                {
                                    new Exercise
                                    {
                                        Name = "Name",
                                        Description = "Description",
                                        Notes = "Notes",
                                        Sets = 2,
                                        Unit = Unit.Lbs,
                                        Weight = 500
                                    }
                                }

                            }
                        }
                    }
                }
            };
            _programService.InsertProgram(request);

            return Ok(Task.FromResult(true));
        }
    }
}
