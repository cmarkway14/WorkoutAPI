namespace Models.Workout_Models;

public class Workout
{
    public string Name { get; set; }

    public List<Exercise> Exercise { get; set; }

    public DayOfWeek WeekDay { get; set; }
}