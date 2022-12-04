namespace Persistence.Data.Config.Base;

using Domain.Models.AccessLevelModels;
using Domain.Models.QUserModels;
using Persistence.Data.Config.AccessConfigs;
using Persistence.Data.Config.AccessLevelConfigs;
using Persistence.Data.Config.CardConfigs;
using Persistence.Data.Config.CardFormatConfigs;
using Persistence.Data.Config.ControllerConfigs;
using Persistence.Data.Config.ControllerConfigs.DoorConfigs;
using Persistence.Data.Config.ControllerConfigs.DoorConfigs.ReaderConfigs;
using Persistence.Data.Config.ControllerConfigs.DoorConfigs.RexConfigs;
using Persistence.Data.Config.DoorGroupConfigs;
using Persistence.Data.Config.QPersonConfigs;

internal static class RegisterEC
{
    public static void ApplyConfiguration(this ModelBuilder modelBuilder, IQClaims qClaims)
    {
        modelBuilder.ApplyConfiguration(new ControllerEC(qClaims));
        modelBuilder.ApplyConfiguration(new ScheduleEC(qClaims));
        modelBuilder.ApplyConfiguration(new ScheduleItemEC(qClaims));
        modelBuilder.ApplyConfiguration(new ReaderEC(qClaims));
        modelBuilder.ApplyConfiguration(new DoorEC(qClaims));
        modelBuilder.ApplyConfiguration(new DoorAdvanceConfigEC(qClaims));
        modelBuilder.ApplyConfiguration(new RexEC(qClaims));
        modelBuilder.ApplyConfiguration(new ReaderIdentificationTypeEC());
        modelBuilder.ApplyConfiguration(new PriorityEC(qClaims));
        modelBuilder.ApplyConfiguration(new DateTimeEC(qClaims));
        modelBuilder.ApplyConfiguration(new CardFormatEC(qClaims));
        modelBuilder.ApplyConfiguration(new CardFormatItemEC(qClaims));
        modelBuilder.ApplyConfiguration(new AreaEC(qClaims));
        modelBuilder.ApplyConfiguration(new AccessLevelEC(qClaims));
        modelBuilder.ApplyConfiguration(new AccessLevelDoorsEC(qClaims));
        modelBuilder.ApplyConfiguration(new QUserAccessLevelsEC(qClaims));
        modelBuilder.ApplyConfiguration(new QUserEC(qClaims));
        modelBuilder.ApplyConfiguration(new QUserFilesEC(qClaims));
        modelBuilder.ApplyConfiguration(new CardEC(qClaims));

        modelBuilder.ApplyConfiguration(new AccessConfigsEC(qClaims));
        modelBuilder.ApplyConfiguration(new ControllerIOPortsEC(qClaims));
        modelBuilder.ApplyConfiguration(new DoorGroupEC(qClaims));
        modelBuilder.ApplyConfiguration(new DoorGroupDoorsEC(qClaims));
    }
}
