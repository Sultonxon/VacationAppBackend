using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace VacationApp.Data.Context;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    private readonly IServiceProvider _serviceProvider;

    public RoleConfiguration(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider.CreateScope().ServiceProvider;
    }
    
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var roles = new List<IdentityRole>
        {
            new IdentityRole("SuperAdmin")
            {
                NormalizedName = roleManager.NormalizeKey("SuperAdmin")
            },
            new IdentityRole("Admin"){
                NormalizedName = roleManager.NormalizeKey("Admin")
            },
            new IdentityRole("Manager")
            {
                NormalizedName = roleManager.NormalizeKey("Manager")
            },
            new IdentityRole("Employee"){
                NormalizedName = roleManager.NormalizeKey("Employee")
            }
        };
        
        builder.HasData(roles);
    }
}