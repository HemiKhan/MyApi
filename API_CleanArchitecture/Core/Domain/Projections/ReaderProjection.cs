namespace Domain.Models.ControllerModels.DoorModels.ReaderModels;

using Domain.Events.ControllerEvents.DoorEvents.ReaderEvents;

public partial record Reader
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                Reader_Created e:
                Apply(e);
                break;
            case
                Reader_Updated e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }
    public void Apply(Reader_Created e)
    {
        DoorId = e.doorId;
        ControllerId = e.controllerId;

        Protocol = e.Protocol;
        LEDType = e.LEDType;
        Name = e.Name;
        Description = e.Description;
        AreaInId = e.AreaIn;
        AreaOutId = e.AreaOut;
        Location = e.Location;
        HeartbeatInterval = e.HeartbeatInterval;
        Timeout = e.Timeout;
        LPNCameraSN = e.LPNCameraSN;
        IsTimeAttendance = e.IsTimeAttendance;
        IsEnrollmentReader = e.IsEnrollmentReader;
        LEDActiveLevel = e.LEDActiveLevel;
        TamperingType = e.TamperingType;
        BeeperType = e.BeeperType;
        ReaderType = e.ReaderType;

        foreach (var dto in e.ReaderIdentificationType)
        {
            ReaderIdentificationType.Add(ReaderModeds.ReaderIdentificationType.Create(ControllerId, dto.IdentificationType, dto.DuringScheduleId, dto.ExceptScheduleId));
        }
    }


    public void Apply(Reader_Updated e)
    {

        if (e.newValue.Protocol != default && e.newValue.Protocol != Protocol)
            Protocol = e.newValue.Protocol;

        if (e.newValue.LEDType != default && e.newValue.LEDType != LEDType)
            LEDType = e.newValue.LEDType;

        if (e.newValue.Name != default && e.newValue.Name != Name)
            Name = e.newValue.Name;

        if (e.newValue.Description != default && e.newValue.Description != Description)
            Description = e.newValue.Description;

        if (e.newValue.AreaInId != default && e.newValue.AreaInId != AreaInId)
            AreaInId = e.newValue.AreaInId;

        if (e.newValue.AreaOutId != default && e.newValue.AreaOutId != AreaOutId)
            AreaOutId = e.newValue.AreaOutId;

        if (e.newValue.Location != default && e.newValue.Location != Location)
            Location = e.newValue.Location;

        if (e.newValue.HeartbeatInterval != default && e.newValue.HeartbeatInterval != HeartbeatInterval)
            HeartbeatInterval = e.newValue.HeartbeatInterval;

        if (e.newValue.Timeout != default && e.newValue.Timeout != Timeout)
            Timeout = e.newValue.Timeout;

        if (e.newValue.LPNCameraSN != default && e.newValue.LPNCameraSN != LPNCameraSN)
            LPNCameraSN = e.newValue.LPNCameraSN;

        if (e.newValue.IsTimeAttendance != default && e.newValue.IsTimeAttendance != IsTimeAttendance)
            IsTimeAttendance = e.newValue.IsTimeAttendance;

        if (e.newValue.IsEnrollmentReader != default && e.newValue.IsEnrollmentReader != IsEnrollmentReader)
            IsEnrollmentReader = e.newValue.IsEnrollmentReader;

        if (e.newValue.LEDActiveLevel != default && e.newValue.LEDActiveLevel != LEDActiveLevel)
            LEDActiveLevel = e.newValue.LEDActiveLevel;

        if (e.newValue.TamperingType != default && e.newValue.TamperingType != TamperingType)
            TamperingType = e.newValue.TamperingType;

        if (e.newValue.BeeperType != default && e.newValue.BeeperType != BeeperType)
            BeeperType = e.newValue.BeeperType;

        if (e.newValue.ReaderType != default && e.newValue.ReaderType != ReaderType)
            ReaderType = e.newValue.ReaderType;

        foreach (var dto in e.newValue.ReaderIdentificationType)
        {

            ReaderIdentificationType.Add(ReaderModeds.ReaderIdentificationType.Create(ControllerId, dto.IdentificationType, dto.DuringScheduleId, dto.ExceptScheduleId));
        }
    }


}
