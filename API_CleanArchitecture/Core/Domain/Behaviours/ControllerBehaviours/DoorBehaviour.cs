namespace Domain.Models.ControllerModels.DoorModels;

using System.Linq;

using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;
using Domain.Dtos.Door;
using Domain.Dtos.ReaderDTOs;
using Domain.Events.ControllerEvents;
using Domain.Events.ControllerEvents.DoorEvents;
using Domain.Models.ControllerModels.DoorModels.ReaderModels;
using Domain.Models.ControllerModels.DoorModels.RexModels;

public partial record Door
{

    public Deleted<Door> Delete()
    {
        var e = new Door_Deleted(this);
        RegisterEvent(e);
        return new Deleted<Door>(this, e);
    }

    public void SetDoorType(DoorType doorType)
    {
        var e = new DoorType_Changed(doorType);
        RegisterEvent(e);
    }

    public void SetDoorState(DoorState doorState)
    {
        var e = new DoorState_Changed(doorState);
        RegisterEvent(e);
    }

    public void AddReader(AddReaderDTO[] command, Door door, Controller controller)
    {
        if (!command.Any())
            return;


        if (controller.IsOneDoor)
        {
            if (command.Count() is not (1 or 2))
                throw QExceptions.DoorExceptions.ReadersMustBeNotBeGreaterThan2OrLessThan1WhenDoorConfigIsEnabled;

            ApplyAndRegisterEvent(command, door);
        }
        else if (!controller.IsOneDoor)
        {
            if (command.Count() is not 1)
                throw QExceptions.DoorExceptions.RexMustBeNotBeEqualTo1WhenOneDoorConfigIsDisabled;

            ApplyAndRegisterEvent(command, door);

        }

    }

    private void ApplyAndRegisterEvent(AddReaderDTO[] command, Door door)
    {
        foreach (var c in command)
        {
            var e = new DoorReader_Added(c, door);
            RegisterEvent(e);
        }
    }

    private void ApplyAndRegisterEvent(Rex_Add_DTO[] command, Door door)
    {
        foreach (var c in command)
        {
            var e = new DoorRex_Added(c, door);
            RegisterEvent(e);
        }
    }

    private void ApplyAndRegisterEvent(Door value)
    {
        var e = new Controller_DoorUpdated(value);
        Apply(e.Values);
        RegisterEvent(e);
    }

    public void AddRex(Rex_Add_DTO[] command, Door door, Controller controller)
    {
        if (!command.Any())
            return;

        if (controller.IsOneDoor)
        {
            if (command.Count() is not (1 or 2))
                throw QExceptions.DoorExceptions.RexMustBeNotBeGreaterThan2OrLessThan1WhenDoorConfigIsEnabled;
            ApplyAndRegisterEvent(command, door);
        }
        else
        {
            if (command.Count() is not 1)
                throw QExceptions.DoorExceptions.RexMustBeNotBeEqualTo1WhenOneDoorConfigIsDisabled;
            ApplyAndRegisterEvent(command, door);

        }

    }

    public void AddDoorAdvanceConfig(AddDoorAdvanceConfgDTO addDoorAdvanceConfgDTO, Controller Controller)
    {
        DoorAdvanceConfiguration_Added? e = new DoorAdvanceConfiguration_Added(addDoorAdvanceConfgDTO);
        RegisterEvent(e);
    }

    public void UpdateDoor(Door_GetById_DTO command)
    {
        var oldVlue = new Door_UpdateEventParameters();
        var newVlue = new Door_UpdateEventParameters();
        var justNameUpdated = true;
        bool doorAdvanceConfigurationChanged = false;
        bool readerChanged = false;
        bool rexChanged = false;
        var hasChanges = false;

        if (!Name.Equals(command.Name))
        {
            oldVlue.Name = Name;
            newVlue.Name = command.Name;
        }

        if (!Lock.Equals(command.Lock))
        {
            oldVlue.Lock = Lock;
            newVlue.Lock = command.Lock;
            justNameUpdated = false;
            hasChanges = true;

        }

        if (!DoorType.Equals(command.DoorType))
        {
            oldVlue.DoorType = DoorType;
            newVlue.DoorType = command.DoorType;
            justNameUpdated = false;
            hasChanges = true;
        }

        doorAdvanceConfigurationChanged = DoorAdvanceConfiguration.Update(command.DoorAdvanceConfig);
        readerChanged = UpdateReaderDto(command.Readers);

        rexChanged = UpdateRexDto(command.Rexes, command.Id);

        if (doorAdvanceConfigurationChanged || rexChanged || readerChanged)
        {
            justNameUpdated = false;
            hasChanges = true;
        }

        if (justNameUpdated)
        {

            var e = new Door_NameUpdated(command.Id, Name, command.Name);
            Apply(command.Name);
            RegisterEvent(e);
        }
        else
        {
            if (hasChanges == true)
            {
                var e = new Door_Updated(command.Id, oldVlue, newVlue);
                RegisterEvent(e);
            }
        }
    }

    public bool UpdateRexDto(IEnumerable<Rex_GetById_DTO> dto, long doorId)
    {
        bool hasChanges = false;
        List<Rex> deleteRexList = new List<Rex>();
        List<Rex> createRexList = new List<Rex>();

        if (!dto.Any())
        {
            return hasChanges;
        }

        foreach (var rex in Rexes)
        {
            if (dto.Any(_ => _.Id != rex.Id))
            {
                deleteRexList.Add(rex);
            }

            foreach (var newValue in dto)
            {
                if (newValue.Id == rex.Id)
                {
                    bool chagesDetected = rex.UpdateRex(newValue, doorId);
                    if (chagesDetected)
                    { hasChanges = true; }
                }
                else
                {

                    var newRex = Rex.Create(newValue.RexConnection, newValue.RexDuringScheduleId, newValue.RexExceptScheduleId,
                                  newValue.IsRexNotUnlockDoor, doorId, newValue.RexType);
                    createRexList.Add(newRex);
                    hasChanges = true;
                }

            }

        }

        foreach (var rexToDelete in deleteRexList)
        {
            var rex = Rexes.FirstOrDefault(r => r.Id == rexToDelete.Id);
            Rexes.Remove(rex!);
        }

        foreach (var rexToAdd in createRexList)
        {
            Rexes.Add(rexToAdd);
        }

        return hasChanges;

    }


    public bool UpdateReaderDto(IEnumerable<Reader_GetById_DTO> dto)
    {
        bool hasChanges = false;
        List<Reader> deleteReaderList = new List<Reader>();
        List<Reader> createReaderList = new List<Reader>();

        if (!dto.Any())
        {
            return hasChanges;
        }

        foreach (var reader in Readers)
        {
            if (dto.Any(_ => _.Id != reader.Id))
            {
                deleteReaderList.Add(reader);
            }

            foreach (Reader_GetById_DTO newValue in dto)
            {
                if (newValue.Id == reader.Id)
                {
                    bool chagesDetected = reader.UpdateReader(newValue);
                    if (chagesDetected) { hasChanges = true; }
                }
                else
                {
                    var identificationtype = newValue.ReaderIdentificationType.ToArray();
                    var newReader = Reader.Create(newValue.controllerId, newValue.doorId, newValue.Name,
                                  newValue.Description, newValue.Protocol, newValue.LEDType, newValue.AreaInId, newValue.AreaOutId
                                    , newValue.Location, newValue.HeartbeatInterval, newValue.Timeout, newValue.LPNCameraSN,
                                  newValue.IsTimeAttendance, newValue.IsEnrollmentReader, newValue.LEDActiveLevel, newValue.TamperingType, newValue.BeeperType, newValue.ReaderType, newValue.ReaderIdentificationType.Select(_ => new Dtos.ControllerDTOs.DoorDTOs.ReaderDTOs.AddReaderIdentificationTypeDTO() { IdentificationType= _.IdentificationType,  DuringScheduleId= _.DuringScheduleId, ExceptScheduleId= _.ExceptScheduleId }).ToArray());
                    createReaderList.Add(newReader);
                    hasChanges = true;
                }

            }

        }

        foreach (var readerToDelete in deleteReaderList)
        {
            var reader = Readers.FirstOrDefault(x => x.Id == readerToDelete.Id);
            Readers.Remove(reader!);
        }

        foreach (var readerToAdd in createReaderList)
        {
            Readers.Add(readerToAdd);
        }

        return hasChanges;

    }
}
