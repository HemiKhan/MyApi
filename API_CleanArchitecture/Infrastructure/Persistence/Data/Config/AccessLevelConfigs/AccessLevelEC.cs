namespace Persistence.Data.Config.AccessLevelConfigs;

using Domain.Models.AccessLevelModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record AccessLevelEC(IQClaims claims) : IEntityTypeConfiguration<AccessLevel>
{
    public void Configure(EntityTypeBuilder<AccessLevel> builder)
    {
        // Default Configuration
        builder.AddDateTimeConfig();
        builder.AddDefaultQConfig();
        builder.AddOrgIdOrder();
        builder.AddToken();
        builder.HasQueryFilter(_ => _.OrganizationId == claims.OrganizationId);


        builder.Property(_=> _.Name)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR(64)");

        builder.HasMany(_ => _.AccessLevelDoors)
            .WithOne(_ => _.AccessLevel)
            .HasForeignKey(_ => _.AccessLevelId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(_ => _.Schedule)
            .WithMany(_ => _.AccessLevelSchdeule)
            .HasForeignKey(_ => _.DuringScheduleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(_ => _.ExceptSchedule)
           .WithMany(_ => _.AccessLevelExceptSchdeule)
           .HasForeignKey(_ => _.ExceptScheduleId)
           .IsRequired(false)
           .OnDelete(DeleteBehavior.NoAction);

        builder.Property(_ => _.DuringScheduleId)
          .HasColumnName("DuringScheduleId")
          .HasColumnType("bigint");

        builder.Property(_ => _.ExceptScheduleId)
         .HasColumnName("ExceptScheduleId")
         .HasColumnType("bigint");
    }
}
