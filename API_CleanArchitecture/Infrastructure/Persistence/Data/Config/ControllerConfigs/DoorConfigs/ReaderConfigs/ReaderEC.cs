namespace Persistence.Data.Config.ControllerConfigs.DoorConfigs.ReaderConfigs;

using Domain.Models.ControllerModels.DoorModels;
using Domain.Models.ControllerModels.DoorModels.ReaderModels;

internal record ReaderEC(IQClaims QClaims) : IEntityTypeConfiguration<Reader>
{
    public void Configure(EntityTypeBuilder<Reader> builder)
    {
        builder.AddDefaultQConfig();

        builder.HasQueryFilter(o => o.OrganizationId == QClaims.OrganizationId);

        builder
            .HasOne(_ => _.Door)
            .WithMany(_ => _.Readers)
            .HasForeignKey(_ => _.DoorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
           .Property(x => x.Name)
           .HasColumnType("NVARCHAR(45)")
           .HasColumnName("Name");

        builder
            .Property(x => x.Description)
            .HasColumnType("NVARCHAR(60)")
            .HasColumnName("Description");

        builder
            .Property(x => x.Location)
            .HasColumnType("NVARCHAR(60)")
            .HasColumnName("Location");

        builder
            .Property(x => x.LPNCameraSN)
            .HasColumnType("NVARCHAR(50)")
            .HasColumnName("LPNCameraSN");

        builder.HasMany(_ => _.ReaderIdentificationType)
            .WithOne(_ => _.Reader)
            .HasForeignKey(_ => _.ReaderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(_ => _.LEDType)
           .HasConversion(
            _ => _.ToString(),
               _ => (LEDType)Enum.Parse(typeof(LEDType), _!))
            .HasColumnName("LEDType")
            .HasColumnType("VARCHAR(15)");

        builder.Property(_ => _.ReaderType)
           .HasConversion(
            _ => _.ToString(),
               _ => (ReaderType)Enum.Parse(typeof(ReaderType), _!))
            .HasColumnName("ReaderType")
            .HasColumnType("VARCHAR(10)");

        builder.Property(_ => _.Protocol)
         .HasConversion(
            _ => _.ToString(),
               _ => (ReaderProtocol)Enum.Parse(typeof(ReaderProtocol), _))
            .HasColumnName("Protocol")
            .HasColumnType("VARCHAR(15)");

        builder
           .HasOne(_ => _.AreaIn)
           .WithOne(_ => _.Reader_AreaIn)
           .IsRequired(false)
           .HasForeignKey<Reader>(_ => _.AreaInId)
           .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(_ => _.AreaOut)
            .WithOne(_ => _.Reader_AreaOut)
            .IsRequired(false)
            .HasForeignKey<Reader>(_ => _.AreaOutId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
