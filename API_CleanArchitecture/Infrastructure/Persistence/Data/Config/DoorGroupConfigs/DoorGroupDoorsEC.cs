namespace Persistence.Data.Config.DoorGroupConfigs;

using Domain.Models.DoorGroupModels;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal record DoorGroupDoorsEC(IQClaims QClaims) : IEntityTypeConfiguration<DoorGroupDoors>
{
    public void Configure(EntityTypeBuilder<DoorGroupDoors> builder)
    {
        builder.HasKey(x => x.Id);
        builder.AddDateTimeConfig();
        builder.HasOne(_ => _.Door).WithMany(x => x.DoorGroupDoors).OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(_ => _.OrganizationId).HasColumnOrder(1);
        builder.Property(_ => _.DoorId).HasColumnType("BIGINT").HasColumnOrder(2);
        builder.Property(_ => _.DoorGroupId).HasColumnType("BIGINT").HasColumnOrder(3);
    }
}
