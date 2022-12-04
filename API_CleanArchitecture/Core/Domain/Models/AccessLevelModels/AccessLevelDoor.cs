namespace Domain.Models.AccessLevelModels;

using Domain.Events.AccessLevelEvents;
using Domain.Models.ControllerModels.DoorModels;
using Domain.Models.ScheduleModels;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record AccessLevelDoor : AggregateRoot<long> , IMustHaveOrganization
{
    private AccessLevelDoor()
    {

    }

    private AccessLevelDoor(long accessLevelId, long doorId,  long scheduleId,  long? exceptScheduleId)
    {
        var e = new AccessLevelDoor_Created
            (
             accessLevelId,
             doorId,
             scheduleId,
             exceptScheduleId
            );
        RegisterEvent(e);
    }

    public AccessLevel AccessLevel { get; private set; } = default!;
    public long AccessLevelId { get; private set; }
    public Door Door { get; private set; } = default!;
    public long DoorId { get; private set; }
    public Schedule Schedule { get; private set; } = default!;
    public long DuringScheduleId { get; private set; }
    public Schedule ExceptSchedule { get; private set; } = default!;
    public long? ExceptScheduleId { get; private set; }
    public long OrganizationId { get; private set; }

    
}
