using Microsoft.AspNetCore.Identity;
using DNAAnalysis.Domain.Entities.IdentityModule;
using DNAAnalysis.Domain.Contracts;
using System.Linq;

namespace DNAAnalysis.Persistence.IdentityData.DataSeed;



public class IdentityDataInitializer : IDataInitializer
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentityDataInitializer(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitializeAsync()
    {
        try
        {
            // 1️⃣ Seed Roles
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }

            // 2️⃣ Seed Users
            if (!_userManager.Users.Any())
            {
                var user01 = new ApplicationUser()
                {
                    DisplayName = "Mariam Ali",
                    UserName = "mariamali",
                    Email = "mariamali@gmail.com",
                    PhoneNumber = "01000000001"
                };

                var user02 = new ApplicationUser()
                {
                    DisplayName = "Ahmed Ali",
                    UserName = "ahmedali",
                    Email = "ahmedali@gmail.com",
                    PhoneNumber = "01000000002"
                };

                await _userManager.CreateAsync(user01, "P@ssw0rd");
                await _userManager.CreateAsync(user02, "P@ssw0rd");

                await _userManager.AddToRoleAsync(user01, "SuperAdmin");
                await _userManager.AddToRoleAsync(user02, "Admin");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while seeding identity data: {ex}");
        }
    }
}

