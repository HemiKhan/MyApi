namespace Domain.Models.ControllerModels.DoorModels.ReaderModeds;

using Domain.Events.ControllerEvents.DoorEvents.ReaderEvents;

public partial record ReaderIdentificationType
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                ReaderIdentificationType_Added e:
                Apply(e);
                break;
            case
                ReaderIdentificationType_Deleted e:
                Apply(e);
                break;
            case
                ReaderIdentificationType_Updated e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }

    public void Apply(ReaderIdentificationType_Added e)
    {
        ControllerId = e.ControllerId;
        IdentificationType = e.IdentificationType;
        DuringScheduleId = e.DuringScheduleId;
        ExceptScheduleId = e.ExceptScheduleId;
    }

    //public void Apply(ReaderIdentificationType_Updated e)
    //{
    //    Id = e.Value.Id;


    //    IdentificationType = e.Value.IdentificationType;
    //    DuringScheduleId = e.Value.DuringScheduleId;
    //    ExceptScheduleId = e.Value.ExceptScheduleId;
    //}
    public void Apply(ReaderIdentificationType_Deleted e)
    {
        Id = e.Value.Id;
    }
    public void Apply(ReaderIdentificationType_Updated e)
    {
        if (e.newValue.IdentificationType != default && e.newValue.IdentificationType != IdentificationType)
            IdentificationType = e.newValue.IdentificationType;
        if (e.newValue.DuringScheduleId != default && e.newValue.DuringScheduleId != DuringScheduleId)
            DuringScheduleId = e.newValue.DuringScheduleId;
        if (e.newValue.ExceptScheduleId != default && e.newValue.ExceptScheduleId != ExceptScheduleId)
            ExceptScheduleId = e.newValue.ExceptScheduleId;
    }
}
