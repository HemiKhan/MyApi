namespace Persistence.Data.Config.AccessLevelConfigs;

using Domain.Models.AccessLevelModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record AccessLevelDoorsEC(IQClaims claims) : IEntityTypeConfiguration<AccessLevelDoor>
{
    public void Configure(EntityTypeBuilder<AccessLevelDoor> builder)
    {
        builder.AddDateTimeConfig();
        builder.AddIdOrder();
        builder.AddOrgIdOrder();
        builder.HasQueryFilter(_ => _.OrganizationId == claims.OrganizationId);

        builder.HasOne(_ => _.Schedule)
            .WithMany(_ => _.AccessLevelDoorSchdeule)
            .HasForeignKey(_ => _.DuringScheduleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(_ => _.ExceptSchedule)
            .WithMany(_ => _.AccessLevelDoorExceptSchdeule)
            .HasForeignKey(_ => _.ExceptScheduleId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(_ => _.Door)
            .WithMany(_ => _.AccessLevelDoors)
            .HasForeignKey(_ => _.DoorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(_ => _.AccessLevelId)
            .HasColumnName("AccessLevelId")
            .HasColumnType("bigint");

        builder.Property(_ => _.DoorId)
             .HasColumnName("DoorId")
             .HasColumnType("bigint");

            builder.Property(_ => _.DuringScheduleId)
           .HasColumnName("DuringScheduleId")
           .HasColumnType("bigint");

    }
}
