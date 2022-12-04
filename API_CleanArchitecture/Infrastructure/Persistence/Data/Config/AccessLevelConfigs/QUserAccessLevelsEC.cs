namespace Persistence.Data.Config.AccessLevelConfigs;

using Domain.Models.AccessLevelModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record QUserAccessLevelsEC(IQClaims claims) : IEntityTypeConfiguration<QUserAccessLevel>
{
    public void Configure(EntityTypeBuilder<QUserAccessLevel> builder)
    {
        builder.AddDateTimeConfig();
        builder.AddDateTimeConfig();
        builder.AddOrgIdOrder();
        builder.HasQueryFilter(_ => _.OrganizationId == claims.OrganizationId);

        builder.HasOne(_=> _.QUser)
            .WithMany(_=> _.QUserAccessLevels)
            .HasForeignKey(_=> _.QUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(_ => _.QUserId)
            .HasColumnName("QUserId")
            .HasColumnType("bigint");

        builder.Property(_ => _.AccessLevelId)
            .HasColumnType("bigint")
            .HasColumnName("AccessLevelId");

    }
}
