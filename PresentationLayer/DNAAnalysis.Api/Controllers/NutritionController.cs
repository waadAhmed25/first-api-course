using DNAAnalysis.ServiceAbstraction;
using DNAAnalysis.Shared.NutritionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DNAAnalysis.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NutritionController : ControllerBase
{
    private readonly INutritionService _nutritionService;

    public NutritionController(INutritionService nutritionService)
    {
        _nutritionService = nutritionService;
    }

    private string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }

    [HttpPost("profile")]
    public async Task<IActionResult> CreateProfile(CreateNutritionProfileDto dto)
    {
        var userId = GetUserId();

        await _nutritionService.CreateProfileAsync(userId, dto);

        return Ok("Profile saved");
    }

    [HttpPost("generate-plan")]
    public async Task<IActionResult> GeneratePlan()
    {
        var userId = GetUserId();

        var plan = await _nutritionService.GeneratePlanAsync(userId);

        if (plan == null)
            return BadRequest("Plan generation failed");

        return Ok(plan);
    }

    [HttpGet("my-plan")]
    public async Task<IActionResult> GetMyPlan()
    {
        var userId = GetUserId();

        var plan = await _nutritionService.GetUserPlanAsync(userId);

        if (plan == null)
            return NotFound("No plan found");

        return Ok(plan);
    }
}