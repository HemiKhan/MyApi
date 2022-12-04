namespace Domain.Models.ControllerModels.DoorModels.RexModels;


public partial record Rex
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                Rex_Created e:
                Apply(e);
                break;
            case
                Rex_Updated e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }
    public void Apply(Rex_Created e)
    {
        RexConnection = e.RexConnection;
        RexDuringScheduleId = e.RexDuringScheduleId;
        RexExceptScheduleId = e.RexExceptScheduleId;
        IsRexNotUnlockDoor = e.IsRexNotUnlockDoor;
        DoorId = e.DoorId;
        RexType = e.RexType;
    }

    public void Apply(Rex_Updated e)
    {
        if (e.newValue.RexConnection != default && e.newValue.RexConnection != RexConnection)
            RexConnection = e.newValue.RexConnection;

        if (e.newValue.RexDuringScheduleId != default && e.newValue.RexDuringScheduleId != RexDuringScheduleId)
            RexDuringScheduleId = e.newValue.RexDuringScheduleId;

        if (e.newValue.RexExceptScheduleId != default && e.newValue.RexExceptScheduleId != RexExceptScheduleId)
            RexExceptScheduleId = e.newValue.RexExceptScheduleId;

        if (e.newValue.IsRexNotUnlockDoor != default && e.newValue.IsRexNotUnlockDoor != IsRexNotUnlockDoor)
            IsRexNotUnlockDoor = e.newValue.IsRexNotUnlockDoor;

        if (e.newValue.DoorId != default && e.newValue.DoorId != DoorId)
            DoorId = e.newValue.DoorId;

        if (e.newValue.RexType != default && e.newValue.RexType != RexType)
            RexType = e.newValue.RexType;

    }
}
