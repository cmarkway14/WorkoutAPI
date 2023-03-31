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
        [Route("insert")]
        public async Task<ActionResult> Insert()
        {

            var request = ProgramBlock();
            _programService.InsertProgram(request);

            return Ok(Task.FromResult(true));
        }

        private static ProgramBlock ProgramBlock()
        {
            var request = new ProgramBlock
            {
                Description = "Power building 3",
                Duration = 16,
                Name = "Power building 3",
                ProgramType = ProgramType.PowerBuilding,
                Weeks = new List<Week>
                {
                    new Week
                    {
                        Name = "Introduction Week",
                        Workouts = new List<Workout>
                        {
                            new Workout
                            {
                                Name = "Day 1",
                                WeekDay = DayOfWeek.Monday,
                                Exercise = new List<Exercise>
                                {
                                    new Exercise
                                    {
                                        Name = "Low Bar Squat",
                                        Description = "4 Reps @ RPE 6, 4 reps @ RPE 7, 4 Reps @ RPE 8. No back off sets",
                                        RestTime = "3-5 Minutes between working sets",
                                        
                                    },
                                    new Exercise
                                    {
                                        Name = "Pin Bench Press Mid Range",
                                        Description = "6 Reps @ RPE 6, 6 reps @ RPE 7, 6 Reps @ RPE 8. No back off sets",
                                        RestTime = "3-5 Minutes between working sets",

                                    },
                                    new Exercise
                                    {
                                        Name = "Mid Shin Rack/Block Pulls",
                                        Description = "8 Reps @ RPE 6, 8 reps @ RPE 7, 8 Reps @ RPE 8. No back off sets",
                                        RestTime = "2-3 Minutes between working sets",

                                    },
                                    new Exercise
                                    {
                                        Name = "Leg Extensions",
                                        Description = "3 x 12-20 reps @ RPE 8-9",
                                        RestTime = "10 minute cap total",
                                    }
                                }
                            },
                            new Workout{},
                            new Workout{},
                            new Workout{},
                        }
                    },
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                    new Week{},
                }
            };
            return request;
        }
    }
}
