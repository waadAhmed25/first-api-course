using System.ComponentModel.DataAnnotations;

namespace DNAAnalysis.Shared.IdentityDtos
{
    public record ResendConfirmationDto(
        [Required]
        [EmailAddress]
        string Email
    );
}
