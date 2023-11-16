using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationApp.Common.Entities;

namespace VacationApp.Data.Context;

public class VacationStatusConfiguration : IEntityTypeConfiguration<VacationStatus>
{
    public void Configure(EntityTypeBuilder<VacationStatus> builder)
    {
        builder.ToTable("VacationStatus");
        builder.HasData(new List<VacationStatus>()
        {
            new VacationStatus("Pending"),
            new VacationStatus("Approved"),
            new VacationStatus("Rejected")
        });
    }
}

