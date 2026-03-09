using DNAAnalysis.Domain.Entities.NutritionModule;

namespace DNAAnalysis.Services.Abstraction;

public interface IAiNutritionClient
{
    Task<NutritionPlan> GeneratePlanAsync(
        double weight,
        double height,
        int age,
        string gender,
        string activityLevel,
        string patientStatus);
}