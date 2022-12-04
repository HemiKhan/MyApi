namespace Persistence.Data.Config.AccessConfigs;

using Application.Interfaces;
using Domain.Models.AccessConfigsModels;
using Domain.Seeding;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record AccessConfigsEC(IQClaims claims) : IEntityTypeConfiguration<AccessConfig>
{
    public void Configure(EntityTypeBuilder<AccessConfig> builder)
    {
        #region Configs
        builder.AddDateTimeConfig();
        builder.AddIdOrder();
        builder.AddOrgIdOrder();
        builder.HasQueryFilter(x => x.OrganizationId == claims.OrganizationId);

        builder.Property(x => x.ConfigKey)
            .HasColumnType("NVARCHAR(255)")
            .HasColumnName("ConfigKey");

        builder.Property(x => x.ConfigValue)
          .HasColumnType("NVARCHAR(MAX)")
          .HasColumnName("ConfigValue");

        builder.Property(x => x.ParentId)
            .HasColumnType("bigint")
            .HasColumnName("ParentId")
            .IsRequired(true);
        #endregion

        #region Seeder
        builder.HasData
            (
             new AccessConfigSeeder()
             {
                 Id = 1,
                 OrganizationId = 1,
                 ConfigKey = "03C_SETTINGS",
                 ConfigValue = "O3C Settings",
                 ParentId = 0,
             },
             new AccessConfigSeeder()
             {
                 Id = 2,
                 OrganizationId = 1,
                 ConfigKey = "O3C_USERNAME",
                 ConfigValue = "",
                 ParentId = 1,
             },
              new AccessConfigSeeder()
              {
                  Id = 3,
                  OrganizationId = 1,
                  ConfigKey = "O3C_PASSWORD",
                  ConfigValue = "",
                  ParentId = 1,
              },
               new AccessConfigSeeder()
               {
                   Id = 4,
                   OrganizationId = 1,
                   ConfigKey = "O3C_DISPATCHER_URL",
                   ConfigValue = "",
                   ParentId = 1,
               },
                new AccessConfigSeeder()
                {
                    Id = 5,
                    OrganizationId = 1,
                    ConfigKey = "O3C_PROTOCOL_TYPE",
                    ConfigValue = "",
                    ParentId = 1,
                },
                 new AccessConfigSeeder()
                 {
                     Id = 6,
                     OrganizationId = 1,
                     ConfigKey = "O3C_SERVER",
                     ConfigValue = "",
                     ParentId = 1,
                 }
            );
        #endregion
    }
}
