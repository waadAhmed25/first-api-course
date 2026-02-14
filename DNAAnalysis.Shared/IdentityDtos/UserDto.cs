using System.ComponentModel.DataAnnotations;

namespace DNAAnalysis.Shared.IdentityDtos;

public record UserDto(
    [EmailAddress] string Email,
    string DisplayName,
    string Token
);
