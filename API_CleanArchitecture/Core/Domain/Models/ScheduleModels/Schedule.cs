namespace Domain.Models.ScheduleModels;

using Domain.Events.ScheduleEvents;
using Domain.Models.AccessLevelModels;
using Domain.Models.ControllerModels.DoorModels;
using Domain.Models.ControllerModels.DoorModels.ReaderModeds;
using Domain.Models.ControllerModels.DoorModels.RexModels;
using SharedKernel.Interfaces;

using Microsoft.AspNetCore.Identity;

public partial record Schedule : AggregateRoot<long>, IMustHaveToken, IMustHaveOrganization
{

    Schedule() { }
    Schedule(string name, string? description, bool isSubtraction)
    {
        var e = new ScheduleInfo_Added(name, description, isSubtraction);
        RegisterEvent(e);
    }
    public string Name { get; private set; } = default!;
    public bool IsSubtraction { get; private set; } = default!;
    public string? Description { get; private set; } = default!;
    public string? Definition { get; private set; } = default!;
    public ICollection<ScheduleItem> ScheduleItems { get; protected set; }
    public string Token { get; set; } = default!;
    public long OrganizationId { get; set; }

    public Rex RexDuringSchedule { get; private set; }
    public Rex RexExceptSchedule { get; private set; }

    public ReaderIdentificationType ReaderIdentificationTypeSchedule { get; private set; }
    public ReaderIdentificationType ReaderIdentificationTypeExceptSchedule { get; private set; }
    public DoorAdvanceConfiguration DoorAdvanceConfigurationForSchedule { get; private set; }
    public DoorAdvanceConfiguration DoorAdvanceConfigurationForUnlockSchedule { get; private set; }

    //Access Levels
    public List<AccessLevelDoor> AccessLevelDoorSchdeule { get; private set; }
    public List<AccessLevelDoor> AccessLevelDoorExceptSchdeule { get; private set; }

    public List<AccessLevel> AccessLevelSchdeule { get; private set; }
    public List<AccessLevel> AccessLevelExceptSchdeule { get; private set; }


}
