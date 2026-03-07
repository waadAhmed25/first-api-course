using DNAAnalysis.Domain.Entities.NutritionModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNAAnalysis.Persistence.Data.Configurations.Nutrition;

public class NutritionPlanConfiguration : IEntityTypeConfiguration<NutritionPlan>
{
    public void Configure(EntityTypeBuilder<NutritionPlan> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TotalCalories)
            .IsRequired();

        builder.Property(x => x.ProteinPercentage)
            .IsRequired();

        builder.Property(x => x.CarbsPercentage)
            .IsRequired();

        builder.Property(x => x.FatPercentage)
            .IsRequired();

        builder.HasMany(x => x.MealSuggestions)
            .WithOne(x => x.NutritionPlan)
            .HasForeignKey(x => x.NutritionPlanId);
    }
}