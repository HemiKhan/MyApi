namespace Persistence.Data.Config.DoorGroupConfigs;

using Domain.Models.DoorGroupModels;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal record DoorGroupEC(IQClaims QClaims) : IEntityTypeConfiguration<DoorGroup>
{
    public void Configure(EntityTypeBuilder<DoorGroup> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(o => o.OrganizationId == QClaims.OrganizationId);
        builder.HasMany(_ => _.DoorGroupDoors)
            .WithOne(_ => _.DoorGroup)
            .HasForeignKey(_ => _.DoorGroupId).OnDelete(DeleteBehavior.Cascade);

        builder.AddDateTimeConfig();


        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(_ => _.OrganizationId).HasColumnOrder(1);
        builder.Property(_ => _.Name).HasColumnType("NVARCHAR(64)").HasColumnOrder(2);
    }
}
