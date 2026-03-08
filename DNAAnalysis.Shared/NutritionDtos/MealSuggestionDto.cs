using DNAAnalysis.Shared.Enums;

namespace DNAAnalysis.Shared.NutritionDtos;

public class MealSuggestionDto
{
    public MealType MealType { get; set; }

    public string FoodName { get; set; } = string.Empty;

    public int Calories { get; set; }
     public int Grams { get; set; }
}