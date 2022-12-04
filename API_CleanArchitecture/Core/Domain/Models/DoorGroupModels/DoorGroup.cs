namespace Domain.Models.DoorGroupModels;
using Domain.Events.DoorGroupEvent;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record DoorGroup : AggregateRoot<long>, IMustHaveOrganization
{
    public DoorGroup()
    {
    }
    public DoorGroup(string Name)
    {
        var e = new DoorGroup_Added(Name);
        RegisterEvent(e);
    }

    public long OrganizationId { get; private set; }
    public string Name { get; private set; } = default!;
    public virtual ICollection<DoorGroupDoors> DoorGroupDoors { get; private set; } = default!;

}
