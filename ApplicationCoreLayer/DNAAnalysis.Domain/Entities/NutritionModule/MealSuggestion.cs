using DNAAnalysis.Domain.Entities;
using DNAAnalysis.Shared.Enums;

namespace DNAAnalysis.Domain.Entities.NutritionModule;

public class MealSuggestion : BaseEntity<int>
{
    public int NutritionPlanId { get; set; }

    public MealType MealType { get; set; }

    public string FoodName { get; set; } = null!;

    public int Calories { get; set; }
       public int Grams { get; set; }

    public NutritionPlan NutritionPlan { get; set; } = null!;
}