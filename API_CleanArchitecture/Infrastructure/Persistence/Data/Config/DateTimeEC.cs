namespace Persistence.Data.Config;

using Domain.Models.TimeZoneModels;

internal record DateTimeEC(IQClaims QClaims) : IEntityTypeConfiguration<ControllerDateTime>
{
    public void Configure(EntityTypeBuilder<ControllerDateTime> builder)
    {

        builder.AddDateTimeConfig();


        builder
       .HasIndex(_ => new { _.OrganizationId });
        builder.HasOne(_ => _.Controller).WithOne(_ => _.ControllerDateTime).HasForeignKey<ControllerDateTime>(_ => _.ControllerId).OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.Id)
            .HasColumnOrder(-2);

        builder.Property(_ => _.OrganizationId)
            .HasColumnName("OrganizationId")
            .HasColumnOrder(-1);
        builder.Property(_ => _.ControllerId)
           .HasColumnName("ControllerId");

        builder.Property(_ => _.IPAddress)
            .HasColumnType("NVARCHAR(39)");
        builder.Property(_ => _.DHCP)
            .HasColumnType("NVARCHAR(39)");
        builder.Property(_ => _.Date)
            .HasColumnType("NVARCHAR(12)");
        builder.Property(_ => _.Time)
            .HasColumnType("NVARCHAR(10)");
        builder.Property(_ => _.TimeZoneValue)
            .HasColumnType("NVARCHAR(60)");
        builder.Property(_ => _.DayLightSaving)
            .HasColumnType("bit");
        builder.Property(_ => _.SetMode)
           .HasColumnType("NVARCHAR(6)");
    }
}