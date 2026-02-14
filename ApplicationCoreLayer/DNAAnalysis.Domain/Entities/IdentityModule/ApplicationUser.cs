using Microsoft.AspNetCore.Identity;

namespace DNAAnalysis.Domain.Entities.IdentityModule;

public class ApplicationUser : IdentityUser
{
     public string DisplayName { get; set; } = default!;
    public Address? Address { get; set; }
    public ICollection<OtpCode> OtpCodes { get; set; } = new HashSet<OtpCode>();

}
