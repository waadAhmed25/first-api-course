using DNAAnalysis.Domain.Contracts;
using DNAAnalysis.Domain.Entities.IdentityModule;
using DNAAnalysis.Persistence.IdentityData.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DNAAnalysis.Persistence;

public class OtpRepository : IOtpRepository
{
    private readonly StoreIdentityDbContext _context;

    public OtpRepository(StoreIdentityDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(OtpCode otp)
    {
        await _context.Set<OtpCode>().AddAsync(otp);
    }

    public async Task<OtpCode?> GetValidOtpAsync(string userId, string code, string purpose)
    {
        return await _context.Set<OtpCode>()
            .Where(o =>
                o.UserId == userId &&
                o.Code == code &&
                o.Purpose == purpose &&
                !o.IsUsed &&
                o.ExpirationTime > DateTime.UtcNow)
            .FirstOrDefaultAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
