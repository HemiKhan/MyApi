namespace Domain.Models;

using Domain.Events;
using Domain.Models.ControllerModels.DoorModels.ReaderModels;

public partial record Area : AggregateRoot<long>, IMustHaveOrganization
{
    Area() { }
    Area(string Name, bool IsEntrance)
    {
        var e = new Area_Added(Name, IsEntrance);
        Apply(e);
        RegisterEvent(e);
    }
    public long OrganizationId { get; private set; }
    public string Name { get; private set; } = default!;
    public bool IsEntrance { get; private set; }

    public Reader Reader_AreaIn { get; set; }
    public Reader Reader_AreaOut { get; set; }
}
