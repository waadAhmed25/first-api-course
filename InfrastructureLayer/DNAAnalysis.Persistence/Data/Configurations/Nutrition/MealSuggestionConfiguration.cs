using DNAAnalysis.Domain.Entities.NutritionModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNAAnalysis.Persistence.Data.Configurations.Nutrition;

public class MealSuggestionConfiguration : IEntityTypeConfiguration<MealSuggestion>
{
    public void Configure(EntityTypeBuilder<MealSuggestion> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FoodName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Calories)
            .IsRequired();

        builder.Property(x => x.MealType)
            .IsRequired();
    }
}