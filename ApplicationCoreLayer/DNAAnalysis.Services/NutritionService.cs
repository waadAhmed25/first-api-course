using AutoMapper;
using DNAAnalysis.Domain.Contracts;
using DNAAnalysis.Domain.Entities.NutritionModule;
using DNAAnalysis.ServiceAbstraction;
using DNAAnalysis.Shared.Enums;
using DNAAnalysis.Shared.NutritionDtos;

namespace DNAAnalysis.Services;

public class NutritionService : INutritionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NutritionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateProfileAsync(string userId, CreateNutritionProfileDto dto)
    {
        var repo = _unitOfWork.GetRepository<NutritionProfile, int>();

        var existingProfile = await repo.GetAsync(x => x.UserId == userId);

        if (existingProfile != null)
        {
            existingProfile.Weight = dto.Weight;
            existingProfile.Height = dto.Height;
            existingProfile.Age = dto.Age;
            existingProfile.Gender = dto.Gender;
            existingProfile.ActivityLevel = dto.ActivityLevel;
            existingProfile.PatientStatus = dto.PatientStatus;

            repo.Update(existingProfile);
        }
        else
        {
            var profile = _mapper.Map<NutritionProfile>(dto);
            profile.UserId = userId;

            await repo.AddAsync(profile);
        }

        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<NutritionPlanDto?> GetUserPlanAsync(string userId)
    {
        var profileRepo = _unitOfWork.GetRepository<NutritionProfile, int>();
        var planRepo = _unitOfWork.GetRepository<NutritionPlan, int>();
        var mealRepo = _unitOfWork.GetRepository<MealSuggestion, int>();

        var profile = await profileRepo.GetAsync(x => x.UserId == userId);

        if (profile == null)
            return null;

        var plan = await planRepo.GetAsync(x => x.NutritionProfileId == profile.Id);

        if (plan == null)
            return null;

        var meals = await mealRepo.GetAllAsync(x => x.NutritionPlanId == plan.Id);

        return new NutritionPlanDto
        {
            TotalCalories = plan.TotalCalories,
            ProteinPercentage = plan.ProteinPercentage,
            CarbsPercentage = plan.CarbsPercentage,
            FatPercentage = plan.FatPercentage,
            Meals = meals.Select(x => new MealSuggestionDto
            {
                MealType = x.MealType,
                FoodName = x.FoodName,
                Calories = x.Calories,
                Grams = x.Grams
            })
        };
    }

    public async Task<NutritionPlanDto?> GeneratePlanAsync(string userId)
    {
        var profileRepo = _unitOfWork.GetRepository<NutritionProfile, int>();
        var planRepo = _unitOfWork.GetRepository<NutritionPlan, int>();
        var mealRepo = _unitOfWork.GetRepository<MealSuggestion, int>();

        var profile = await profileRepo.GetAsync(x => x.UserId == userId);

        if (profile == null)
            throw new Exception("Nutrition profile not found");

        var existingPlan = await planRepo.GetAsync(x => x.NutritionProfileId == profile.Id);

        if (existingPlan != null)
        {
            return await GetUserPlanAsync(userId);
        }

        // Fake AI result for now
        var plan = new NutritionPlan
        {
            NutritionProfileId = profile.Id,
            TotalCalories = 2560,
            ProteinPercentage = 20,
            CarbsPercentage = 45,
            FatPercentage = 35
        };

        await planRepo.AddAsync(plan);
        await _unitOfWork.SaveChangeAsync();

        var meals = new List<MealSuggestion>
        {
            new MealSuggestion
            {
                NutritionPlanId = plan.Id,
                MealType = MealType.Breakfast,
                FoodName = "Scrambled Eggs",
                Calories = 302,
                Grams = 150
            },
            new MealSuggestion
            {
                NutritionPlanId = plan.Id,
                MealType = MealType.Lunch,
                FoodName = "Chicken Soup",
                Calories = 320,
                Grams = 200
            },
            new MealSuggestion
            {
                NutritionPlanId = plan.Id,
                MealType = MealType.Dinner,
                FoodName = "Soft Pasta",
                Calories = 400,
                Grams = 220
            },
            new MealSuggestion
            {
                NutritionPlanId = plan.Id,
                MealType = MealType.Snack,
                FoodName = "Yogurt",
                Calories = 150,
                Grams = 120
            }
        };

        foreach (var meal in meals)
        {
            await mealRepo.AddAsync(meal);
        }

        await _unitOfWork.SaveChangeAsync();

        return await GetUserPlanAsync(userId);
    }
}