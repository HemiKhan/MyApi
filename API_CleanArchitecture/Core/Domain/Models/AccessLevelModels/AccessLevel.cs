namespace Domain.Models.AccessLevelModels;

using Domain.Events.AccessLevelEvents;
using Domain.Models.QUserModels;
using Domain.Models.ScheduleModels;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record AccessLevel : AggregateRoot<long>, IMustHaveOrganization, IMustHaveToken
{
    private AccessLevel(string name,  long scheduleId, long? exceptScheduleId)
    {
        var e = new AccessLevel_Created
            (
            name,
            scheduleId,
            exceptScheduleId
            );
        RegisterEvent(e);
    }

    private AccessLevel()
    {

    }
    public long OrganizationId { get; private set; } = default!;
    public Schedule Schedule { get; private set; } = default!;
    public long DuringScheduleId { get; private set; }
    public Schedule ExceptSchedule { get; private set; } = default!;
    public long? ExceptScheduleId { get; private set; }
    public string Token { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public List<AccessLevelDoor> AccessLevelDoors { get; private set; } = new();

   
}
