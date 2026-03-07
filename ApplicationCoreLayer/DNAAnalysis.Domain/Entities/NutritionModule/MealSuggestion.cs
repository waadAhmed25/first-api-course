namespace DNAAnalysis.Domain.Entities.NutritionModule;

public class MealSuggestion
{
    public int Id { get; set; }

    public int NutritionPlanId { get; set; }

    public MealType MealType { get; set; }

    public string FoodName { get; set; } = null!;

    public int Calories { get; set; }

    public NutritionPlan NutritionPlan { get; set; } = null!;
}