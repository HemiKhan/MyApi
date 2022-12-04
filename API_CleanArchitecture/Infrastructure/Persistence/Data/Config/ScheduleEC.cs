namespace Persistence.Data.Config;

using Domain.Models.ScheduleModels;
using Domain.Seeding;

using System.Globalization;

internal record ScheduleEC(IQClaims QClaims) : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        #region Configuration    
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(o => o.OrganizationId == QClaims.OrganizationId);
        builder.HasMany(_ => _.ScheduleItems).WithOne(_ => _.Schedules).HasForeignKey(_ => _.ScheduleId);
        builder.AddDateTimeConfig();
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(_ => _.OrganizationId).HasColumnOrder(1);
        builder.Property(_ => _.Name).HasColumnType("NVARCHAR(64)").HasColumnOrder(2);
        builder.Property(_ => _.Token).HasColumnType("NVARCHAR(64)").HasColumnOrder(3);
        builder.Property(_ => _.IsSubtraction).HasColumnType("BIT");
        builder.Property(_ => _.Description).HasColumnType("NVARCHAR(128)");
        builder.Property(_ => _.Definition).HasColumnType("NVARCHAR(MAX)");
        #endregion

        #region Seeder
        builder.HasData(
               new SchedulesSeeder
               {
                   Id = 1,
                   OrganizationId = -1,
                   Name = "Always",
                   Description = "Always active (standard schedule)",
                   Token = "standard_always",
                   IsSubtraction = false,
               },
                new SchedulesSeeder
                {
                    Id = 2,
                    OrganizationId = -1,
                    Name = "Office Hours",
                    Description = "Example office hours (9AM to 5PM)",
                    Token = "standard_office_hours",
                    IsSubtraction = false,
                },
                new SchedulesSeeder
                {
                    Id = 3,
                    OrganizationId = -1,
                    Name = "Weekends",
                    Description = "Example weekend time incl. friday evening",
                    Token = "standard_weekends",
                    IsSubtraction = false,
                },
                  new SchedulesSeeder
                  {
                      Id = 4,
                      OrganizationId = -1,
                      Name = "After Hours",
                      Description = "Example after hours (5PM to 9AM) incl. weekends",
                      Token = "standard_after_hours",
                      IsSubtraction = false,
                  }
            );

        #endregion

    }
}
