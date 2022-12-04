namespace Domain.Models.ControllerModels.DoorModels;

using Domain.Dtos.Door;
using Domain.Events.ControllerEvents.DoorEvents;
using Domain.Models.ControllerModels.DoorModels.ReaderModels;
using Domain.Models.ControllerModels.DoorModels.RexModels;

public partial record Door
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                Door_Created e:
                Apply(e);
                break;
            case
                DoorAdvanceConfiguration_Added e:
                Apply(e);
                break;
            case
                DoorState_Changed e:
                Apply(e);
                break;
            case
                DoorType_Changed e:
                Apply(e);
                break;
            case
                DoorReader_Added e:
                Apply(e);
                break;
            case
                DoorRex_Added e:
                Apply(e);
                break;
            case
                Door_Updated e:
                Apply(e);
                break;
            case
                Door_Deleted e:
                Apply(e);
                break;

            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }
    //public static Door Create(string name, string @lock, Controller controller)
    //{
    //    var o = new Door(

    //         name,
    //         @lock,
    //         controller
    //    );

    //    return o;
    //}

    public static Door Create(Door_Add_DTO c, Controller controller)
    {
        var door = new Door(

             c.Name,
             c.Lock.ToString(),
             c.DoorType,
             controller
        );

        door.AddDoorAdvanceConfig(c.DoorAdvanceConfig, controller);
        door.AddReader(c.Readers, door, controller);
        door.AddRex(c.Rexes, door, controller);
        return door;
    }


    public void Apply(Door_Created e)
    {
        Name = e.Name;
        Lock = e.Lock;
        DoorType = e.DoorType;
        ControllerId = e.Controller.Id;
    }

    public void Apply(string name)
    {
        Name = name;
    }


    public void Apply(Door e)
    {
        Name = e.Name;
        Lock = e.Lock;
        ControllerId = e.ControllerId;
        DoorType = e.DoorType;
        DoorAdvanceConfiguration = e.DoorAdvanceConfiguration;
        Readers = e.Readers;
        Rexes = e.Rexes;
    }

    public void Apply(DoorAdvanceConfiguration_Added e)
    {
        DoorAdvanceConfiguration = DoorAdvanceConfiguration.Create(
            new AddDoorAdvanceConfgDTO
            (
                e.Values.DuringScheduleId,
                e.Values.UnlockScheduleId,
                e.Values.IsDoorMonitor,
                e.Values.DoorMonitorValues,
                e.Values.IsLockMonitor,
                e.Values.LockMonitorValues,
                e.Values.EnableSupervisedInputs,
                e.Values.AccessTime,
                e.Values.LongAccessTime,
                e.Values.LockWhenLocked,
                e.Values.LockWhenUnlocked,
                e.Values.RelayStateLocked,
                e.Values.BoltInTime,
                e.Values.BoltOutTime,
                e.Values.IsAntiPassback,
                e.Values.AntiPassbackValues
            ));
    }


    public void Apply(Door_Deleted e)
    {
        Name = e.DoorType.Name;
        Lock = e.DoorType.Lock;
        ControllerId = e.DoorType.ControllerId;
        DoorType = e.DoorType.DoorType;

    }
    public void Apply(DoorState_Changed e)
    {
        State = e.State;
    }
    public void Apply(DoorType_Changed e)
    {
        DoorType = e.DoorType;
    }


    public void Apply(DoorReader_Added e)
    {
        var reader = Reader.Create(
               e.Door.ControllerId,
               e.Door.Id,
               e.Values.Name,
               e.Values.Description!,
               e.Values.Protocol,
               e.Values.LEDType,
               e.Values.AreaInId,
               e.Values.AreaOutId,
               e.Values.Location!,
               e.Values.HeartbeatInterval,
               e.Values.Timeout,
               e.Values.LPNCameraSN!,
               e.Values.IsTimeAttendance,
               e.Values.IsEnrollmentReader,
               e.Values.LEDActiveLevel,
               e.Values.TamperingType,
               e.Values.BeeperType,
               e.Values.ReaderType,
               e.Values.ReaderIdentificationType!
              );
        Readers.Add(reader);
    }

    public void Apply(DoorRex_Added e)
    {
        var rex = Rex.Create
            (
            e.Values.RexConnection,
            e.Values.RexDuringScheduleId,
            e.Values.RexExceptScheduleId,
            e.Values.IsRexNotUnlockDoor,
            e.Door.Id,
            e.Values.RexType
            );
        Rexes.Add(rex!);
    }


    public void Apply(Door_Updated e)
    {
        if (e.New.Name != default && e.New.Name != Name)
            Name = e.New.Name;

        if (e.New.Lock != default && e.New.Lock != Lock)
            Lock = e.New.Lock;

        if (e.New.DoorType != default && e.New.DoorType != DoorType)
            DoorType = e.New.DoorType;
    }

}
