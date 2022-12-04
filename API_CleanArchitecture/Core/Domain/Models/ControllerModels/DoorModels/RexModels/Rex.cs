namespace Domain.Models.ControllerModels.DoorModels.RexModels;

using Domain.Constants;
using Domain.Models.ScheduleModels;
using SharedKernel.Interfaces;

public partial record Rex : Entity<long>, IMustHaveOrganization
{
    Rex() { }
    Rex(ActiveType rexConnection, long rexDuringSchedule, long? rexExceptSchedule, bool isRexNotUnlockDoor, long doorId, RexType rexType)
    {
        var e = new Rex_Created(rexConnection, rexDuringSchedule, rexExceptSchedule, isRexNotUnlockDoor, doorId, rexType);
        Apply(e);
        RegisterEvent(e);
    }

    public ActiveType RexConnection { get; private set; }

    public bool IsRexNotUnlockDoor { get; private set; }

    public RexType RexType { get; private set; }

    public Schedule RexDuringSchedule { get; private set; } = default!;
    public Schedule? RexExceptSchedule { get; private set; } = default!;
    public long RexDuringScheduleId { get; private set; }
    public long? RexExceptScheduleId { get; private set; }
    public long DoorId { get; private set; }
    public Door Door { get; private set; } = default!;
    public long OrganizationId { get; set; }
}
