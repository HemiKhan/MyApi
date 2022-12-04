namespace Persistence.Data.Config;

using Domain.Models.PrioritiesModels;
using Domain.Seeding;

using Microsoft.EntityFrameworkCore.Metadata.Builders;


internal record PriorityEC(IQClaims qClaims) : IEntityTypeConfiguration<Priority>
{
    public void Configure(EntityTypeBuilder<Priority> builder)
    {
        #region Conifguration

        builder.AddOrgIdOrder();
        builder.AddIdOrder();

        builder.HasQueryFilter(_ => _.OrganizationId == qClaims.OrganizationId);

        builder.Property(_ => _.Name)
            .HasColumnType("NVARCHAR(64)")
            .HasColumnName("Name");

        builder.Property(_ => _.PriorityLevel)
            .HasColumnName("PriortyLevel")
            .HasColumnType("int");

        builder.Property(_ => _.ColorCode)
            .HasColumnName("ColorCode")
            .HasColumnType("NVARCHAR(10)");

        #endregion

        #region Seeder
        builder.HasData(
               new PrioritiesSeeder
               {
                   Id = 1,
                   OrganizationId = -1,
                   Name = "High",
                   ColorCode = "#FF0000", //Red
                   PriortyLevel = 1,
               },
                new PrioritiesSeeder
                {
                    Id = 2,
                    OrganizationId = -1,
                    Name = "Medium",
                    ColorCode = "#FFFF00", //Yellow
                    PriortyLevel = 2,
                },
                new PrioritiesSeeder
                {
                    Id = 3,
                    OrganizationId = -1,
                    Name = "Low",
                    ColorCode = "#00FF00", //Green
                    PriortyLevel = 3,
                },
                  new PrioritiesSeeder
                  {
                      Id = 4,
                      OrganizationId = -1,
                      Name = "None",
                      ColorCode = "#000000", //White
                      PriortyLevel = 4,
                  }
            );

        #endregion
    }
}
