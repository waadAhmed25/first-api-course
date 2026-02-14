using DNAAnalysis.Shared.CommonResult;
using Microsoft.AspNetCore.Mvc;

namespace DNAAnalysis.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiBaseController : ControllerBase
{
    protected ActionResult<T> HandleResult<T>(Result<T> result)
    {
        if (result is null)
            return NotFound();

        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(result.Errors);
    }
}
