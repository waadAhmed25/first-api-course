using DNAAnalysis.Shared.Enums;

namespace DNAAnalysis.Shared.NutritionDtos;

public class CreateNutritionProfileDto
{
    public double Weight { get; set; }

    public double Height { get; set; }

    public int Age { get; set; }

    public Gender Gender { get; set; }

    public ActivityLevel ActivityLevel { get; set; }

    public PatientStatus PatientStatus { get; set; }
}