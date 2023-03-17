namespace Models.Workout_Models;

public class Exercise
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int Sets { get; set; }

    public double Weight { get; set; }

    public Unit Unit { get; set; }

    public string Notes { get; set; }
}