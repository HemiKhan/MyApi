namespace Domain.Models.ControllerModels;

using Domain.Events.ControllerEvents;
using Domain.Models.ControllerModels.DoorModels;
using Domain.Models.OutputSensorModel;
using Domain.Models.TimeZoneModels;

public partial record Controller : AggregateRoot<long>, IMustHaveOrganization, IMustHaveToken
{
    Controller() { }

    Controller(string name, string userName, string password, string mACAddress, string oAK, bool isOneDoor, ControllerModel controllerModel)
    {
        var e = new Controller_Added(name, userName, password, mACAddress, oAK, isOneDoor, controllerModel);
        RegisterEvent(e);
    }

    public long OrganizationId { get; private set; }
    public string Token { get; private set; } = string.Empty;
    public List<Door> Doors { get; } = new();

    public string Name { get; private set; } = default!;
    public string UserName { get; private set; } = default!;
    public string Password { get; private set; } = default!;
    public string MACAddress { get; private set; } = default!;
    public string OAK { get; private set; } = default!;
    public bool IsOneDoor { get; private set; } = default!;
    public bool Status { get; private set; } = default!;
    public bool IsDoor1Added { get; private set; } = default!;
    public bool IsDoor2Added { get; private set; } = default!;

    public ControllerModel Model { get; private set; } = ControllerModel.A1601;


    /// <summary>
    /// State whether we can add Door or not
    /// </summary>
    public ControllerState State { get; private set; } = ControllerState.Pending;
    public string? UUID { get; private set; }
    public virtual ICollection<ControllerIOPorts> ControllerIOPorts { get; set; } = default!;
    public virtual ControllerDateTime ControllerDateTime { get; set; } = default!;

}

