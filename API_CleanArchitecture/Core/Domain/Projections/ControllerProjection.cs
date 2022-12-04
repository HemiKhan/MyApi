namespace Domain.Models.ControllerModels;

using Domain.Events.ControllerEvents;
using Domain.Models.ControllerModels.DoorModels;

// Projection
// Just Apply Methods
public partial record Controller
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                Controller_Added e:
                Apply(e);
                break;
            case
                Controller_DoorConfigUpdated e:
                Apply(e);
                break;
            case
                Controller_NameUpdated e:
                Apply(e);
                break;
            case
                Controller_PasswordUpdated e:
                Apply(e);
                break;
            case
                Controller_MACAddressUpdated e:
                Apply(e);
                break;
            case
                Controller_OAKUpdated e:
                Apply(e);
                break;
            case
                Controller_ModelUpdated e:
                Apply(e);
                break;
            case
                Controller_UserNameUpdated e:
                Apply(e);
                break;
            case
                Controller_Door1StatusAdded e:
                Apply(e);
                break;
            case
                Controller_DoorAdded e:
                Apply(e);
                break;
            case
                Controller_Door2StatusAdded e:
                Apply(e);
                break;
            case
                Controller_Deleted e:
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }

    private void Apply(Controller_Added e)
    {
        Name = e.Name;
        UserName = e.UserName;
        Password = e.Password;
        MACAddress = e.MACAddress;
        OAK = e.OAK;
        IsOneDoor = e.IsOneDoor;
        Model = e.Model;
    }

    private void Apply(Controller_DoorConfigUpdated ev)
    {
        IsOneDoor = ev.New;
    }

    private void Apply(Controller_NameUpdated ev)
    {
        Name = ev.New;
    }

    private void Apply(Controller_PasswordUpdated ev)
    {
        Password = ev.New;
    }

    private void Apply(Controller_MACAddressUpdated ev)
    {
        MACAddress = ev.New;
    }

    private void Apply(Controller_OAKUpdated ev)
    {
        OAK = ev.New;
    }

    private void Apply(Controller_ModelUpdated ev)
    {
        Model = ev.New;
    }

    private void Apply(Controller_UserNameUpdated ev)
    {
        UserName = ev.New;
    }

    private void Apply(Controller_Door1StatusAdded e)
    {
        IsDoor1Added = e.Status;
    }

    private void Apply(Controller_DoorAdded e)
    {

        var door = Door.Create(e.Values, this);

        Doors.Add(door);
    }

    private void Apply(Controller_DoorUpdated e)
    {




    }
    private void Apply(Controller_Door2StatusAdded e)
    {
        IsDoor2Added = e.New;
    }
}
