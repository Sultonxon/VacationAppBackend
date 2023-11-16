using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VacationApp.Common.Entities;

namespace VacationApp.Data.Context;

public class AppDbContext : IdentityDbContext<UserEntity>
{
    private readonly IServiceProvider _serviceProvider;

    public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider serviceProvider) : base(options)
    {
        _serviceProvider = serviceProvider;
    }
    
    public DbSet<VacationEntity> Vacations { get; set; }
    public DbSet<VacationStatus> VacationStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<VacationEntity>()
            .HasOne(v => v.Status);

        builder.ApplyConfiguration(new RoleConfiguration(_serviceProvider));
        builder.ApplyConfiguration(new VacationStatusConfiguration());
    }
}
