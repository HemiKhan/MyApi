namespace Persistence.Data.Config.ControllerConfigs.DoorConfigs.ReaderConfigs;

using Domain.Models.ControllerModels.DoorModels.ReaderModeds;

using Microsoft.EntityFrameworkCore.Metadata.Builders;


public record ReaderIdentificationTypeEC() : IEntityTypeConfiguration<ReaderIdentificationType>
{
    public void Configure(EntityTypeBuilder<ReaderIdentificationType> builder)
    {
        builder.AddDateTimeConfig();
        builder.AddIdOrder();

        builder
            .HasOne(_ => _.Reader)
            .WithMany(_ => _.ReaderIdentificationType)
            .HasForeignKey(_ => _.ReaderId);

        builder
            .Property(_ => _.IdentificationType)
             .HasColumnType("VARCHAR(25)")
            .HasConversion(
                    _ => _.ToString(),
                    _ => (IdentificationType)Enum.Parse(typeof(IdentificationType), _));


        builder
            .HasOne(_ => _.Schedule)
            .WithOne(_ => _.ReaderIdentificationTypeSchedule)
            .IsRequired(false)
            .HasForeignKey<ReaderIdentificationType>(f => f.DuringScheduleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(_ => _.ExceptSchedule)
            .WithOne(_ => _.ReaderIdentificationTypeExceptSchedule)
            .IsRequired(false)
            .HasForeignKey<ReaderIdentificationType>(f => f.ExceptScheduleId)
            .OnDelete(DeleteBehavior.NoAction);



        var exceptScheduleIndex = builder.Metadata
          .FindIndex(builder.Property(_ => _.ExceptScheduleId).Metadata);

        if (exceptScheduleIndex is not null)
        {
            builder.Metadata.RemoveIndex(exceptScheduleIndex);
            builder
                .HasIndex(_ => _.ExceptScheduleId)
                .IsUnique(false);
        }

        var scheduleIndex = builder.Metadata
          .FindIndex(builder.Property(_ => _.DuringScheduleId).Metadata);

        if (scheduleIndex is not null)
        {
            builder.Metadata.RemoveIndex(scheduleIndex);
            builder
                .HasIndex(_ => _.DuringScheduleId)
                .IsUnique(false);
        }
       

    }
}
