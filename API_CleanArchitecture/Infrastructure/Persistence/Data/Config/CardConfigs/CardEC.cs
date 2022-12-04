using Domain.Models.CardModels;
using Domain.Models.QUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Config.CardConfigs
{
    public record CardEC(IQClaims claims) : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.AddDateTimeConfig();
            builder.AddDefaultQConfig();
            builder.AddIdOrder();
            builder.AddOrgIdOrder();
            builder.HasQueryFilter(_ => _.OrganizationId == claims.OrganizationId);

            builder.HasOne(_ => _.QUser)
           .WithMany(_ => _.Cards)
           .HasForeignKey(_ => _.QUserId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnType("NVARCHAR(255)");

            builder.Property(p => p.CardNumber)
           .HasColumnName("CardNumber")
           .HasColumnType("NVARCHAR(255)");

            builder.Property(p => p.CardRaw)
           .HasColumnName("CardRaw")
           .HasColumnType("NVARCHAR(255)");

            builder.Property(p => p.Pin)
           .HasColumnName("Pin")
           .HasColumnType("NVARCHAR(10)");

            builder.Property(p => p.FacilityCode)
           .HasColumnName("FacilityCode")
           .HasColumnType("int ");

            builder.Property(p => p.ValidFrom)
           .HasColumnName("ValidFrom")
           .HasColumnType("datetime2");

            builder.Property(p => p.ValidTo)
           .HasColumnName("ValidTo")
           .HasColumnType("datetime2");

            builder.Property(p => p.QUserId)
           .HasColumnName("QUserId")
           .HasColumnType("bigint");

            builder.Property(p => p.LastAccessDoorId)
           .HasColumnName("LastAccessDoorId")
           .HasColumnType("bigint");

            builder.Property(p => p.LastAccessAreaId)
           .HasColumnName("LastAccessAreaId")
           .HasColumnType("bigint");

            builder.Property(p => p.CardStatus)
           .HasColumnType("VARCHAR(50)")
            .HasConversion(
                    _ => _.ToString(),
                    _ => (CardStatus)Enum.Parse(typeof(CardStatus), _));

            builder.Property(p => p.LpnNumber)
            .HasColumnName("LpnNumber")
            .HasColumnType("NVARCHAR(255)");



        }
    }
}
