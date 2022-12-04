namespace Persistence.Data.Config;

using Application.Common;
using Domain.Models.OutputSensorModel;
using Domain.Models.ScheduleModels;
using Domain.Seeding;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal record ControllerIOPortsEC(IQClaims QClaims) : IEntityTypeConfiguration<ControllerIOPorts>
{
    public void Configure(EntityTypeBuilder<ControllerIOPorts> builder)
    {
        #region Configuration    
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(o => o.OrganizationId == QClaims.OrganizationId);
        builder.HasOne(_ => _.Controller).WithMany(_ => _.ControllerIOPorts).HasForeignKey("ControllerId").OnDelete(DeleteBehavior.Cascade);
        builder.AddDateTimeConfig();
        builder.Property(x => x.Id).HasColumnOrder(0);
        builder.Property(_ => _.OrganizationId).HasColumnOrder(1);
        builder.Property(_ => _.ControllerId).HasColumnOrder(2);
        builder.Property(_ => _.Name).HasColumnType("NVARCHAR(64)").HasColumnOrder(3);
        builder.Property(_ => _.PortType).HasColumnType("NVARCHAR(7)").HasColumnOrder(4);
        builder.Property(_ => _.State).HasColumnType("NVARCHAR(18)").HasColumnOrder(5);
        builder.Property(_ => _.Status).HasColumnType("NVARCHAR(64)").HasColumnOrder(6);
        builder.Property(_ => _.IONumber).HasColumnType("int").HasColumnOrder(7);
        #endregion
    }
}
