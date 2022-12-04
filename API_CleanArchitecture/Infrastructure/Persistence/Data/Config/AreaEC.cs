namespace Persistence.Data.Config;

using Domain.Models;
using Domain.Models.ScheduleModels;
using Domain.Seeding;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal record AreaEC(IQClaims QClaims) : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        #region Configuration    
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(o => o.OrganizationId == QClaims.OrganizationId);
        builder.AddDateTimeConfig();
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(_ => _.OrganizationId).HasColumnOrder(1);
        builder.Property(_ => _.Name).HasColumnType("NVARCHAR(64)").HasColumnOrder(2);
        builder.Property(_ => _.IsEntrance).HasColumnType("BIT").HasColumnOrder(3);
        #endregion

    }
}
