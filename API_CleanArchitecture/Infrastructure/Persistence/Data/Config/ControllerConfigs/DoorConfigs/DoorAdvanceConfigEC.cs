namespace Persistence.Data.Config.ControllerConfigs.DoorConfigs;

using Domain.Models.ControllerModels.DoorModels;

using Microsoft.EntityFrameworkCore;

internal record DoorAdvanceConfigEC(IQClaims QClaims) : IEntityTypeConfiguration<DoorAdvanceConfiguration>
{
    public void Configure(EntityTypeBuilder<DoorAdvanceConfiguration> builder)
    {
        builder.AddDateTimeConfig();

        builder.HasIndex(_ => new { _.Id })
        .IsUnique();

        builder.HasQueryFilter(o => o.OrganizationId == QClaims.OrganizationId);


        builder
            .HasOne(_ => _.Schedule)
            .WithOne(_ => _.DoorAdvanceConfigurationForSchedule)
            .IsRequired(false)
            .HasForeignKey<DoorAdvanceConfiguration>(_ => _.DuringScheduleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(_ => _.UnlockSchedule)
            .WithOne(_ => _.DoorAdvanceConfigurationForUnlockSchedule)
            .IsRequired(false)
            .HasForeignKey<DoorAdvanceConfiguration>(_ => _.UnlockScheduleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .Property(x => x.DoorMonitor)
            .HasConversion(
            _ => _.ToString(),
               _ => (DoorMonitor)Enum.Parse(typeof(DoorMonitor), _))
            .HasColumnType("NVARCHAR(30)")
            .HasColumnName("DoorMonitor");

        builder.Property(x => x.AccessTime)
            .HasColumnName("AccessTime");

        builder.Property(x => x.LongAccessTime)
            .HasColumnName("LongAccessTime");

        builder.Property(x => x.OpenTooLongTime)
            .HasColumnName("OpenTooLongTime");

        builder.Property(x => x.PreAlarmTime)
            .HasColumnName("PreAlarmTime");

        builder.Property(x => x.LockWhenLocked)
            .HasColumnType("VARCHAR(5)")
            .HasColumnName("LockWhenLocked");

        builder.Property(x => x.LockWhenUnlocked)
            .HasColumnType("VARCHAR(5)")
            .HasColumnName("LockWhenUnlocked");

        builder.Property(x => x.RelayStateLocked)
            .HasColumnType("VARCHAR(8)")
            .HasColumnName("RelayStateLocked")
            .HasConversion(
                _ => _.ToString(),
                _ => (RelayStateLockedType)Enum.Parse(typeof(RelayStateLockedType), _));

        builder.Property(x => x.BoltInTime)
            .HasColumnName("BoltInTime");

        builder.Property(x => x.BoltOutTime)
            .HasColumnName("BoltOutTime");


        builder.Property(x => x.AntipassbackMode)
            .HasColumnType("VARCHAR(15)")
            .HasColumnName("AntipassbackMode")
            .IsRequired(false)
            .HasConversion(
            _ => _.ToString(),
            _ => (AntipassbackModeType)Enum.Parse(typeof(AntipassbackModeType), _));

        builder.Property(x => x.AntiPassbackEnforcementMode)
            .HasColumnType("VARCHAR(10)")
            .HasColumnName("AntiPassbackEnforcementMode")
            .IsRequired(false)
            .HasConversion(
            _ => _.ToString(),
            _ => (AntiPassbackEnforcementModeType)Enum.Parse(typeof(AntiPassbackEnforcementModeType), _));

        builder.Property(x => x.AntiPassbackTimeout)
            .HasColumnName("AntiPassbackTimeout")
            .IsRequired(false);

        var exceptScheduleIndex = builder.Metadata
            .FindIndex(builder.Property(_ => _.DuringScheduleId).Metadata);

        if (exceptScheduleIndex is not null)
        {
            builder.Metadata.RemoveIndex(exceptScheduleIndex);
            builder
                .HasIndex(_ => _.DuringScheduleId)
                .IsUnique(false);
        }

        var scheduleIndex = builder.Metadata
          .FindIndex(builder.Property(_ => _.UnlockScheduleId).Metadata);

        if (scheduleIndex is not null)
        {
            builder.Metadata.RemoveIndex(scheduleIndex);
            builder
                .HasIndex(_ => _.UnlockScheduleId)
                .IsUnique(false);
        }

    }
}
