namespace Domain.Models.ControllerModels;

using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.ControllerDTOs;
using Domain.Dtos.Door;
using Domain.Events.ControllerEvents;
using Domain.Models.ControllerModels.DoorModels;


// Behaviours
public partial record Controller
{

    public static Controller Create(AddControllerCommand command) => new Controller(
                       command.Name,
                       command.UserName,
                       command.Password,
                       command.MACAddress,
                       command.OAK,
                       command.IsOneDoor,
                       command.Model);



    public Deleted<Controller> Delete()
    {
        var e = new Controller_Deleted(this);
        RegisterEvent(e);
        return new Deleted<Controller>(this, e);
    }


    public void RemoveDoor(Door? door)
    {
        if (!Doors.Any(_ => _.Id == door!.Id))
            throw new QException("Door Doesn't Exist with doorId in the Controller");

        if (IsOneDoor)
        {
            if (door!.DoorType is DoorType.Door)
            {
                ChangeDoor2AddedStatus(false);
                if (IsDoor1Added)
                {
                    ChageDoor1AddedStatus(false);
                    var deletingDoor = door.Delete().Entity;
                    var tDoor = Doors.FirstOrDefault(_ => _.Id == deletingDoor.Id);
                    Doors.Remove(tDoor);
                    return;
                }
            }
            throw new QException("Unable To delete Door because doorType is not Not Door when Controller Has OneDoorConfig.");
        }

        if (door!.DoorType is DoorType.Door1)
        {
            if (!Doors.Any(_ => _.Id.Equals(door.Id)))
                throw new QException("Door Doesn't Exist with doorId in the Controller");

            ChageDoor1AddedStatus(false);
            var deletingDoor = door.Delete().Entity;
            var tDoor = Doors.FirstOrDefault(_ => _.Id == deletingDoor.Id);
            Doors.Remove(tDoor);
            return;
        }

        if (door.DoorType is DoorType.Door2)
        {
            if (!Doors.Any(_ => _.Id.Equals(door.Id)))
                throw new QException("Door Doesn't Exist with doorId in the Controller");

            ChangeDoor2AddedStatus(false);
            var deletingDoor = door.Delete().Entity;
            var tDoor = Doors.FirstOrDefault(_ => _.Id == deletingDoor.Id);
            Doors.Remove(tDoor);
            return;

        }


    }

    public void Update(Update_ControllerDTO dto)
    {
        if (!IsOneDoor.Equals(dto.IsOneDoor))
        {
            var ev = new Controller_DoorConfigUpdated(Id, IsOneDoor, dto.IsOneDoor);
            RegisterEvent(ev);
        }

        if (!Name.Equals(dto.Name))
        {
            var ev = new Controller_NameUpdated(Id, Name, dto.Name);
            RegisterEvent(ev);
        }
        if (!UserName.Equals(dto.UserName))
        {
            var ev = new Controller_UserNameUpdated(Id, UserName, dto.UserName);
            RegisterEvent(ev);
        }
        if (!string.IsNullOrEmpty(dto.Password))
        {
            if (!Password.Equals(dto.Password))
            {
                var ev = new Controller_PasswordUpdated(Id, Password, dto.Password);
                RegisterEvent(ev);
            }
        }
        if (!MACAddress.Equals(dto.MACAddress))
        {
            var ev = new Controller_MACAddressUpdated(Id, MACAddress, dto.MACAddress);
            RegisterEvent(ev);
        }
        if (!OAK.Equals(dto.OAK))
        {
            var ev = new Controller_OAKUpdated(Id, OAK, dto.OAK);
            RegisterEvent(ev);
        }

        if (!OAK.Equals(dto.OAK))
        {
            var ev = new Controller_ModelUpdated(Id, Model, dto.Model);
            RegisterEvent(ev);
        }

    }


    public void ChageDoor1AddedStatus(bool isDoor1Added = true)
    {
        if (!IsDoor1Added.Equals(isDoor1Added))
        {
            var e = new Controller_Door1StatusAdded(isDoor1Added);
            RegisterEvent(e);
        }
    }

    public void ChangeDoor2AddedStatus(bool isDoor2Added = true)
    {
        if (!IsDoor2Added.Equals(isDoor2Added))
        {
            var e = new Controller_Door2StatusAdded(Id, IsDoor2Added, isDoor2Added);
            RegisterEvent(e);
        }
    }

    private void ApplyAndRegisterEvent(Door_Add_DTO value)
    {
        var e = new Controller_DoorAdded(value);
        RegisterEvent(e);
    }



    public void AddDoor(Door_Add_DTO door)
    {


        if (IsOneDoor)
        {
            if (door.DoorType is not DoorType.Door)
                throw new QException("DoorType must be 'Door' when Controller has OneDoorConfig enable.");
            if (IsDoor1Added)
                throw new QException("Door Already Exist.");
            ValidateDoorLock(door);
            ApplyAndRegisterEvent(door);
            ChageDoor1AddedStatus();
            ChangeDoor2AddedStatus(false);
            return;
        }

        if (door.DoorType is DoorType.Door)
            throw new QException("DoorType must not be 'Door' when Controller has TwoDoorConfig enable.");

        if (door.DoorType is DoorType.Door1)
        {
            if (IsDoor1Added)
                throw new QException("Door1 Already Exist.");
            ValidateDoorLock(door);
            ApplyAndRegisterEvent(door);
            ChageDoor1AddedStatus();
            return;
        }


        if (door.DoorType is DoorType.Door2)
        {
            if (IsDoor2Added)
                throw new QException("Door2 Already Exist.");
            ValidateDoorLock(door);
            ApplyAndRegisterEvent(door);
            ChangeDoor2AddedStatus();
            return;
        }
        throw new("All doors already exist.");
    }

    private void ValidateDoorLock(Door_Add_DTO door)
    {
        if (IsOneDoor)
        {
            var lockTypes = door.Lock.Split(':');
            if (lockTypes.Length != 2)
                throw new QException("LockTypes Length is Invalid.");

            var lock1 = lockTypes[0];
            var lock2 = lockTypes[1];

            if (Model is ControllerModel.A1001)
            {
                if (!((lock1 is "12V" || lock1 is "Relay") && (lock2 is "12V" || lock2 is "Relay" || lock2 is "None")))
                    throw new QException("Lock 1 Must be '12V' or 'Relay' & Lock 2 Must be '12V' or 'Relay' or 'None'.");

                if (lock1 is "Relay")
                {
                    if (!(lock2 is "None" || lock2 is "12V"))
                        throw new QException("Lock 1 Must be 'Relay' and Lock 2 Must be '12V' or 'None'.");
                }

                if (lock1 is "12V")
                {
                    if (lock2 is not "Relay")
                        throw new QException("Lock 1 Must be '12V' and Lock 2 Must be 'Relay'.");
                }

            }
            else if (Model is ControllerModel.A1601)
            {
                if (lock1 is not "Relay" && (lock2 is not "Relay" || lock2 is not "None"))
                    throw new QException("LockType Must be 'Relay' & 'Relay' or 'None'.");
            }
        }
        else
        {
            if (door.DoorType is DoorType.Door1)
            {
                if (Model is ControllerModel.A1001)
                {
                    if (!(door.Lock is "12V" || door.Lock is "Relay"))
                        throw new QException("LockType Must be '12V' Or 'Relay'.");
                }
                else if (Model is ControllerModel.A1601)
                {
                    if (door.Lock is not "Relay")
                        throw new QException("LockType Must be 'Relay'.");
                }
            }

            if (door.DoorType is DoorType.Door2)
            {
                if (Model is ControllerModel.A1001)
                {
                    var firstDoor = Doors.FirstOrDefault();
                    if (firstDoor is null)
                    {
                        if (!(door.Lock is "12V" || door.Lock is "Relay" || door.Lock is "None"))
                            throw new QException("LockType Must be '12V' or 'Relay' or 'None'.");
                    }
                    else
                    {
                        if (firstDoor.Lock is "Relay")
                        {
                            if (!(door.Lock is "12V" || door.Lock is "None"))
                                throw new QException("LockType Must be '12V' or 'None'.");
                        }
                    }
                }
                else if (Model is ControllerModel.A1601)
                {
                    if (!(door.Lock is "Relay" || door.Lock is "None"))
                        throw new QException("LockType Must be 'Relay' or 'None'.");
                }

            }
        }
    }


    public void UpdateDoor(Door_GetById_DTO updateDto)
    {
        // var door = Door.GetDoorObject();
        // door.UpdateDoor(updateDto);
    }




}

