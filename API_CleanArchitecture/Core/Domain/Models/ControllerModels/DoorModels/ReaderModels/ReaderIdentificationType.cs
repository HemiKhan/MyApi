namespace Domain.Models.ControllerModels.DoorModels.ReaderModeds;

using Domain.Constants;
using Domain.Events.ControllerEvents.DoorEvents.ReaderEvents;
using Domain.Models.ControllerModels.DoorModels.ReaderModels;
using Domain.Models.ScheduleModels;

public partial record ReaderIdentificationType : AggregateRoot<long>
{
    ReaderIdentificationType() { }


    ReaderIdentificationType(long controllerId, IdentificationType identificationType, long? duringScheduleId, long? exceptScheduleId)
    {
        var e = new ReaderIdentificationType_Added(controllerId, identificationType, duringScheduleId, exceptScheduleId);
        Apply(e);
        RegisterEvent(e);
    }

    public long ControllerId { get; private set; } = default!;
    public long ReaderId { get; private set; } = default!;
    public IdentificationType IdentificationType { get; private set; } = default!;
    public long? DuringScheduleId { get; private set; } = default!;
    public long? ExceptScheduleId { get; private set; } = default!;
    public Schedule Schedule { get; private set; } = default!;
    public Schedule ExceptSchedule { get; private set; } = default!;
    public Reader Reader { get; private set; } = default!;
}
