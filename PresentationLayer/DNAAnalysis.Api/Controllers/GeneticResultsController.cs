using DNAAnalysis.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DNAAnalysis.API.Responses;

namespace DNAAnalysis.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneticResultsController : ControllerBase
    {
        private readonly IGeneticResultService _resultService;

        public GeneticResultsController(IGeneticResultService resultService)
        {
            _resultService = resultService;
        }

        [Authorize]
        [HttpGet("{requestId}")]
        public async Task<ActionResult<ApiResponse<object>>> GetResult(int requestId)
        {
            var result = await _resultService.GetResultByRequestIdAsync(requestId);

            if (result == null)
                return NotFound(new ApiResponse<string>(
                    new List<string> { "Result not found" }, "Not Found"));

            return Ok(new ApiResponse<object>(
                result,
                "Genetic result retrieved successfully"));
        }
    }
}