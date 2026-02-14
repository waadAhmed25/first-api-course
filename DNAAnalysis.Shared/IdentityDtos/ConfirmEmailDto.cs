using System.ComponentModel.DataAnnotations;

namespace DNAAnalysis.Shared.IdentityDtos
{
    public record ConfirmEmailDto(
        [Required]
        [EmailAddress]
        string Email,

        [Required]
        string OtpCode
    );
}
