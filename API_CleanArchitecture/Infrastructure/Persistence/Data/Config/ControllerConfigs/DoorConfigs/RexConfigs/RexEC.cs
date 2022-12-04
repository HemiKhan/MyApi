namespace Persistence.Data.Config.ControllerConfigs.DoorConfigs.RexConfigs;

using System;

using Domain.Models.ControllerModels.DoorModels.RexModels;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

public record RexEC(IQClaims claims) : IEntityTypeConfiguration<Rex>
{
    public void Configure(EntityTypeBuilder<Rex> builder)
    {
        builder
     .HasOne(_ => _.Door)
     .WithMany(_ => _.Rexes)
     .HasForeignKey(_ => _.DoorId)
     .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(o => o.OrganizationId == claims.OrganizationId);

        builder.Property(_ => _.RexConnection)
                  .HasConversion(
                  _ => _.ToString(),
                     _ => (ActiveType)Enum.Parse(typeof(ActiveType), _))
                  .HasColumnName("RexConnection")
                  .HasColumnType("VARCHAR(15)");

        builder.Property(_ => _.RexType)
                  .HasConversion(
                  _ => _.ToString(),
                     _ => (RexType)Enum.Parse(typeof(RexType), _))
                  .HasColumnName("RexType")
                  .HasColumnType("VARCHAR(10)");


        builder
            .HasOne(_ => _.RexDuringSchedule)
            .WithOne(_ => _.RexDuringSchedule)
           .IsRequired(false)
            .HasForeignKey<Rex>(_ => _.RexDuringScheduleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(_ => _.RexExceptSchedule)
            .WithOne(_ => _.RexExceptSchedule)
            .IsRequired(false)
            .HasForeignKey<Rex>(_ => _.RexExceptScheduleId)
            .OnDelete(DeleteBehavior.Restrict);




        var exceptScheduleIndex = builder.Metadata
          .FindIndex(builder.Property(_ => _.RexExceptScheduleId).Metadata);

        if (exceptScheduleIndex is not null)
        {
            builder.Metadata.RemoveIndex(exceptScheduleIndex);
            builder
                .HasIndex(_ => _.RexExceptScheduleId)
                .IsUnique(false);
        }

        var scheduleIndex = builder.Metadata
          .FindIndex(builder.Property(_ => _.RexDuringScheduleId).Metadata);

        if (scheduleIndex is not null)
        {
            builder.Metadata.RemoveIndex(scheduleIndex);
            builder
                .HasIndex(_ => _.RexDuringScheduleId)
                .IsUnique(false);
        }

    }
}
