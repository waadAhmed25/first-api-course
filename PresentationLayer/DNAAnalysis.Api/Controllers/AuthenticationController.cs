using DNAAnalysis.Services.Abstraction;
using DNAAnalysis.Shared.IdentityDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace DNAAnalysis.Api.Controllers;

public class AuthenticationController : ApiBaseController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var result = await _authenticationService.LoginAsync(loginDto);
        return HandleResult(result);
    }

    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        var result = await _authenticationService.RegisterAsync(registerDto);
        return HandleResult(result);
    }

[HttpGet("emailexist")]
public async Task<ActionResult<bool>> CheckEmail(string email)
{
    var result = await _authenticationService.CheckEmailAsync(email);
    return Ok(result);
}

[HttpGet("CurrentUser")]
[Authorize]
public async Task<ActionResult<UserDto>> GetCurrentUser()
{
    var Email = User.FindFirstValue(ClaimTypes.Email);

    var result = await _authenticationService
        .GetUserByEmailAsync(Email!);

    return HandleResult(result);
}

[HttpPost("confirm-email")]
public async Task<ActionResult<bool>> ConfirmEmail(ConfirmEmailDto dto)
{
    var result = await _authenticationService.ConfirmEmailAsync(dto);
    return HandleResult(result);
}

[HttpPost("resend-confirmation")]
public async Task<ActionResult<bool>> ResendConfirmation(ResendConfirmationDto dto)
{
    var result = await _authenticationService.ResendConfirmationAsync(dto);
    return HandleResult(result);
}

[HttpPost("forgot-password")]
public async Task<ActionResult<bool>> ForgotPassword(ForgotPasswordDto dto)
{
    var result = await _authenticationService.ForgotPasswordAsync(dto);
    return HandleResult(result);
}

[HttpPost("reset-password")]
public async Task<ActionResult<bool>> ResetPassword(ResetPasswordDto dto)
{
    var result = await _authenticationService.ResetPasswordAsync(dto);
    return HandleResult(result);
}




}
