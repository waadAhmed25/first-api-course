using DNAAnalysis.Domain.Entities.NutritionModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNAAnalysis.Persistence.Data.Configurations.Nutrition;

public class NutritionProfileConfiguration : IEntityTypeConfiguration<NutritionProfile>
{
    public void Configure(EntityTypeBuilder<NutritionProfile> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Weight)
            .IsRequired();

        builder.Property(x => x.Height)
            .IsRequired();

        builder.Property(x => x.Age)
            .IsRequired();

        builder.Property(x => x.Gender)
            .IsRequired();

        builder.Property(x => x.ActivityLevel)
            .IsRequired();

        builder.Property(x => x.PatientStatus)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.HasOne(x => x.NutritionPlan)
            .WithOne(x => x.NutritionProfile)
            .HasForeignKey<NutritionPlan>(x => x.NutritionProfileId);
    }
}