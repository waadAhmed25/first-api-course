using System.ComponentModel.DataAnnotations;

namespace DNAAnalysis.Shared.IdentityDtos
{
    public record ResetPasswordDto(
        [Required]
        [EmailAddress]
        string Email,

        [Required]
        string OtpCode,

        [Required]
        string NewPassword
    );
}
