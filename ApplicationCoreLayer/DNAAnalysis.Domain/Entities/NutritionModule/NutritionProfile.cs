namespace DNAAnalysis.Domain.Entities.NutritionModule;

public class NutritionProfile
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public double Weight { get; set; }

    public double Height { get; set; }

    public int Age { get; set; }

    public Gender Gender { get; set; }

    public ActivityLevel ActivityLevel { get; set; }

    public PatientStatus PatientStatus { get; set; }

    public NutritionPlan? NutritionPlan { get; set; }
}