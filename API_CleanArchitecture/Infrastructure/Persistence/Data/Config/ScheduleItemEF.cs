namespace Persistence.Data.Config;

using Domain.Models.ScheduleModels;

internal record ScheduleItemEC(IQClaims QClaims) : IEntityTypeConfiguration<ScheduleItem>
{
    public void Configure(EntityTypeBuilder<ScheduleItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.AddDateTimeConfig();
        builder.Property(x => x.Id).HasColumnOrder(1);
        builder.Property(_ => _.ScheduleId)
            .HasColumnType("BIGINT").HasColumnOrder(2);
        builder.Property(_ => _.Summary)
            .HasColumnType("NVARCHAR(64)").HasColumnOrder(3);
        builder.Property(_ => _.ItemDefinition)
            .HasColumnType("NVARCHAR(MAX)").HasColumnOrder(4);
        builder.Property(_ => _.StartTime)
            .HasColumnType("NVARCHAR(5)").HasColumnOrder(5);
        builder.Property(_ => _.EndTime)
            .HasColumnType("NVARCHAR(5)").HasColumnOrder(6);
        builder.Property(_ => _.RecurrenceDays)
            .HasColumnType("NVARCHAR(40)").HasColumnOrder(7);
        builder.Property(_ => _.IsAllDay).HasColumnType("BIT").HasColumnOrder(8);
        builder.Property(_ => _.IsWeekly).HasColumnType("BIT").HasColumnOrder(9);
        builder.Property(_ => _.IsRecurrence).HasColumnType("BIT").HasColumnOrder(10);
        builder.Property(_ => _.IsEndBy).HasColumnType("BIT").HasColumnOrder(11);
        builder.Property(_ => _.StartDate)
            .HasColumnType("DATETIME").HasColumnOrder(12);
        builder.Property(_ => _.EndDate)
            .HasColumnType("DATETIME").HasColumnOrder(13);
        builder.Property(_ => _.EndBy)
            .HasColumnType("DATETIME").HasColumnOrder(14);

    }
}
