using AutoMapper;
using DNAAnalysis.Domain.Entities.NutritionModule;
using DNAAnalysis.Shared.NutritionDtos;

namespace DNAAnalysis.Services.MappingProfiles;

public class NutritionMappingProfile : Profile
{
    public NutritionMappingProfile()
    {
        CreateMap<CreateNutritionProfileDto, NutritionProfile>();
    }
}