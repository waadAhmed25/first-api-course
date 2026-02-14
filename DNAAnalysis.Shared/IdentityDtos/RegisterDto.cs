using System.ComponentModel.DataAnnotations;

namespace DNAAnalysis.Shared.IdentityDtos;

public record RegisterDto(
    [EmailAddress] string Email,
    string DisplayName,
    string UserName,
    string Password,
    [Phone] string PhoneNumber
);
