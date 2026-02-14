using System.ComponentModel.DataAnnotations;

namespace DNAAnalysis.Shared.IdentityDtos;

public record LoginDto(
    [EmailAddress] string Email,
    string Password
);
