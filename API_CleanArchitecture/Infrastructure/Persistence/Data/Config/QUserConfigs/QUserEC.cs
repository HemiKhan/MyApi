namespace Persistence.Data.Config.QPersonConfigs;

using Domain.Models.QUserModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record QUserEC(IQClaims claims) : IEntityTypeConfiguration<QUser>
{
    public void Configure(EntityTypeBuilder<QUser> builder)
    {
        builder.AddDateTimeConfig();
        builder.AddDefaultQConfig();
        builder.AddIdOrder();
        builder.AddOrgIdOrder();
        builder.HasQueryFilter(_ => _.OrganizationId == claims.OrganizationId);

        builder.HasOne(_ => _.QUserFiles)
         .WithOne(_ => _.QUser)
         .HasForeignKey<QUserFile>(_ => _.QUserId)
         .OnDelete(DeleteBehavior.Cascade);

        builder.Property(_ => _.FirstName)
            .HasColumnName("FirstName")
            .HasColumnType("NVARCHAR(64)");

        builder.Property(_ => _.LastName)
           .HasColumnName("LastName")
           .HasColumnType("NVARCHAR(64)");

        builder.Property(_ => _.MiddleName)
          .HasColumnName("MiddleName")
          .HasColumnType("NVARCHAR(64)");

        builder.Property(_ => _.EmployeeId)
         .HasColumnName("EmployeeId")
         .HasColumnType("NVARCHAR(40))");

        builder.Property(_ => _.Email)
         .HasColumnName("Email")
         .HasColumnType("NVARCHAR(254)");

        builder.Property(_ => _.DepartmentName)
            .HasColumnType("VARCHAR(64)")
            .HasColumnName("DepartmentName");

        builder.Property(_ => _.CompanyName)
           .HasColumnType("NVARCHAR(100)")
           .HasColumnName("CompanyName");

        builder.Property(_ => _.Gender)
           .HasColumnType("VARCHAR(6)")
           .HasColumnName("Gender");

        builder.Property(_ => _.QUserType)
           .HasColumnType("VARCHAR(64)")
           .HasColumnName("QUserType");


        builder.Property(_ => _.Phone)
           .HasColumnType("NVARCHAR(16)")
           .HasColumnName("Phone");

        builder.Property(_ => _.LastArea)
           .HasColumnType("NVARCHAR(64)")
           .HasColumnName("LastArea");

        builder.Property(_ => _.LastUse)
          .HasColumnType("DateTime")
          .HasColumnName("LastUse");

        builder.Property(_ => _.LastLocation)
        .HasColumnType("NVARCHAR(64)")
        .HasColumnName("LastLocation");

        builder.Property(_ => _.IsUnlockExtensionADA)
        .HasColumnType("bit")
        .HasColumnName("IsUnlockExtensionADA");

        builder.Property(_ => _.LastLocation)
            .HasColumnType("NVARCHAR(64)")
            .HasColumnName("LastLocation");

        builder.Property(_ => _.Nationality)
            .HasColumnType("NVARCHAR(100)")
            .HasColumnName("Nationality");
    }
}
