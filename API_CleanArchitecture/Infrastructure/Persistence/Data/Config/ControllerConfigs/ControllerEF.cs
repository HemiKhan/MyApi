namespace Persistence.Data.Config.ControllerConfigs;

using Domain.Models.ControllerModels;



internal record ControllerEC(IQClaims QClaims) : IEntityTypeConfiguration<Controller>
{
    public void Configure(EntityTypeBuilder<Controller> builder)
    {

        builder.AddDateTimeConfig();


        builder
       .HasIndex(_ => new { _.OrganizationId, _.Name })
       .IsUnique();

        builder.HasQueryFilter(o => o.OrganizationId == QClaims.OrganizationId);


        //builder.Property(x => x.Doors);
        //.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);

        builder.Property(x => x.Id)
            .HasColumnOrder(-2);

        builder.Property(_ => _.OrganizationId)
            .HasColumnName("OrganizationId")
            .HasColumnOrder(-1);


        builder.Property(_ => _.Name)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR(64)");

        builder.Property(_ => _.Token)
            .HasColumnName("Token")
            .HasColumnType("VARCHAR(64)");

        builder.Property(_ => _.UserName)
              .HasColumnName("UserName")
            .HasColumnType("NVARCHAR(100)");

        builder.Property(_ => _.Password)
                  .HasColumnName("Password")
            .HasColumnType("NVARCHAR(100)");

        builder.Property(_ => _.MACAddress)

            .HasColumnName("MACAddress")
            .HasColumnType("VARCHAR(17)");

        builder.Property(_ => _.OAK)
               .HasColumnName("OAK")
               .HasColumnType("VARCHAR(75)");

        builder.Property(_ => _.UUID)
                      .HasColumnName("UUID")
            .HasColumnType("VARCHAR(60)");

        builder.Property(_ => _.State)
            .HasConversion(
                    _ => _.ToString(),
                    _ => (ControllerState)Enum.Parse(typeof(ControllerState), _))
            .HasColumnName("State")
            .HasColumnType("VARCHAR(25)");


        builder.Property(_ => _.Model)
            .HasConversion(_ => _.ToString(), _ => (ControllerModel)Enum.Parse(typeof(ControllerModel), _))
                     .HasColumnType("VARCHAR(15)");



    }
}
