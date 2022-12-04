using Domain.Events.ControllerEvents.DoorEvents;
using Domain.Models.AccessLevelModels;
using Domain.Models.ControllerModels.DoorModels.ReaderModels;
using Domain.Models.ControllerModels.DoorModels.RexModels;
using Domain.Models.DoorGroupModels;

namespace Domain.Models.ControllerModels.DoorModels;

public partial record Door : AggregateRoot<long>, IMustHaveOrganization, IMustHaveToken
{
    Door() { }

    Door(string name, string @lock, DoorType doorType, Controller controller)
    {
        var e = new Door_Created(name, @lock, doorType, controller);
        RegisterEvent(e);
    }


    public string Token { get; set; } = string.Empty;
    public long OrganizationId { get; set; }

    public Controller Controller { get; private set; } = default!;
    public long ControllerId { get; private set; }

    public DoorAdvanceConfiguration DoorAdvanceConfiguration { get; private set; } = default!;

    public List<Reader> Readers { get; private set; } = new();

    public List<Rex> Rexes { get; private set; } = new();



    public string Lock { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public DoorState State { get; private set; } = DoorState.Unknown;

    public DoorType DoorType { get; private set; }

    public List<AccessLevelDoor> AccessLevelDoors { get; private set; }
    public virtual IEnumerable<DoorGroupDoors> DoorGroupDoors { get; private set; }
}
