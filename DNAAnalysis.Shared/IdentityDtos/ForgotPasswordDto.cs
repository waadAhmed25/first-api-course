using System.ComponentModel.DataAnnotations;

namespace DNAAnalysis.Shared.IdentityDtos
{
    public record ForgotPasswordDto(
        [Required]
        [EmailAddress]
        string Email
    );
}
