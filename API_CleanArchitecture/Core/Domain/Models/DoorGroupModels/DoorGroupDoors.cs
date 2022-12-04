namespace Domain.Models.DoorGroupModels;

using Domain.Events.DoorGroupEvent;
using Domain.Models.ControllerModels.DoorModels;
using SharedKernel.Interfaces;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record DoorGroupDoors : AggregateRoot<long>, IMustHaveOrganization
{
    public DoorGroupDoors()
    {
    }
    public DoorGroupDoors(long DoorId, long DoorGroupId)
    {
        var e = new DoorGroupDoor_Added(DoorGroupId, DoorId);
        RegisterEvent(e);
    }
    public long OrganizationId { get; private set; }
    public long DoorId { get; private set; }
    [ForeignKey("DoorGroup")]
    public long DoorGroupId { get; private set; }
    public virtual Door Door { get; private set; } = default!;
    public DoorGroup DoorGroup { get; private set; } = default!;
}
