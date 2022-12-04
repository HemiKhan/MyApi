namespace Domain.Models.AccessConfigsModels;

using Domain.Dtos.AccessConfigDTOs;
using Domain.Events.AccessConfigEvents;


public partial record AccessConfig
{
  public void Update(UpdateAccessConfigDTO dto)
    {
        var Old = new UpdateAccessConfigParameters();
        var New = new UpdateAccessConfigParameters();

        if (!dto.ConfigValue!.Equals(ConfigValue))
        {
            Old.ConfigValue = ConfigValue;
            New.ConfigValue = dto.ConfigValue;
        }
        if (!dto.ConfigKey!.Equals(ConfigKey))
        {
            Old.ConfigKey = ConfigKey;
            New.ConfigKey = dto.ConfigKey;
        }

        New.Id = Id;
        var e = new AccessConfigUpdated(Old, New);
        RegisterEvent(e);
    }
}
