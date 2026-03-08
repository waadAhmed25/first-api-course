namespace DNAAnalysis.Shared.NutritionDtos;

public class NutritionPlanDto
{
    public int TotalCalories { get; set; }

    public double ProteinPercentage { get; set; }

    public double CarbsPercentage { get; set; }

    public double FatPercentage { get; set; }

    public IEnumerable<MealSuggestionDto> Meals { get; set; } = new List<MealSuggestionDto>();
}