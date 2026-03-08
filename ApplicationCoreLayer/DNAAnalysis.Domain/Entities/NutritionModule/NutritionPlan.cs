using DNAAnalysis.Domain.Entities;

namespace DNAAnalysis.Domain.Entities.NutritionModule;

public class NutritionPlan : BaseEntity<int>
{
    public int NutritionProfileId { get; set; }

    public int TotalCalories { get; set; }

    public double ProteinPercentage { get; set; }

    public double CarbsPercentage { get; set; }

    public double FatPercentage { get; set; }

    public NutritionProfile NutritionProfile { get; set; } = null!;

    public ICollection<MealSuggestion> MealSuggestions { get; set; } = new List<MealSuggestion>();
}