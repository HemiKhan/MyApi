namespace Persistence.Data.Config.ControllerConfigs.DoorConfigs
{
    using Domain.Models.ControllerModels.DoorModels;

    internal record DoorEC(IQClaims Claims) : IEntityTypeConfiguration<Door>
    {
        public void Configure(EntityTypeBuilder<Door> builder)
        {
            builder.AddDefaultQConfig();

            //builder.HasIndex(_ => new { _.OrganizationId, _.Name })
            //.IsUnique();

            builder.HasQueryFilter(o => o.OrganizationId == Claims.OrganizationId);


            builder
           .HasOne(_ => _.Controller)
           .WithMany(_ => _.Doors)
           .HasForeignKey(_ => _.ControllerId)
           .OnDelete(DeleteBehavior.Cascade);


            builder
            .HasOne(_ => _.DoorAdvanceConfiguration)
            .WithOne(_ => _.Door)
            .HasForeignKey<DoorAdvanceConfiguration>(_ => _.DoorId)
            .OnDelete(DeleteBehavior.Cascade);



            builder.Property(_ => _.Name)
                .HasColumnType("NVARCHAR(64)");
            //.HasConversion(_ => _.Value, _ => new(_));

            builder.Property(_ => _.Lock)
                .HasColumnType("NVARCHAR(15)");

            builder.Property(_ => _.DoorType)
               .HasConversion(
                     _ => _.ToString(),
                     _ => (DoorType)Enum.Parse(typeof(DoorType), _))
                .HasColumnName("DoorType")
                .HasColumnType("NVARCHAR(15)");

            builder.Property(_ => _.State)
                .HasConversion(
                _ => _.ToString(),
                   _ => (DoorState)Enum.Parse(typeof(DoorState), _))
                .HasColumnName("DoorState")
                .HasColumnType("NVARCHAR(15)");


        }
    }
}
