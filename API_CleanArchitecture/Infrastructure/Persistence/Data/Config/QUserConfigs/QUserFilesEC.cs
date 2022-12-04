namespace Persistence.Data.Config.QPersonConfigs;

using Domain.Models.QUserModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record QUserFilesEC(IQClaims claims) : IEntityTypeConfiguration<QUserFile>
{
    public void Configure(EntityTypeBuilder<QUserFile> builder)
    {
        builder.AddDateTimeConfig();
        builder.AddIdOrder();
        builder.AddOrgIdOrder();
        builder.HasQueryFilter(_=> _.OrganizationId == claims.OrganizationId);

      

        builder.Property(_ => _.QUserId)
            .HasColumnName("QUserId");

        builder.Property(_ => _.ImageData)
            .HasColumnType("VARBINARY(MAX)")
            .HasColumnName("ImageData");

        builder.Property(_ => _.ImageName)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("ImageName");

    }
}
