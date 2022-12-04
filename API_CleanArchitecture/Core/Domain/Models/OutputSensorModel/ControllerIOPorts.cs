namespace Domain.Models.OutputSensorModel;
using Domain.Constants;
using Domain.Events;
using Domain.Events.ControllerEvents.DoorEvents.ReaderEvents;
using Domain.Models.ControllerModels;
using Domain.Models.ScheduleModels;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record ControllerIOPorts : AggregateRoot<long>, IMustHaveOrganization
{
    ControllerIOPorts() { }
    ControllerIOPorts(long Id, long ControllerId, string Name, PortType PortType, State State, string Status, int IoNumber)
    {

        var e = new ControllerIoPorts_Added(Id, ControllerId, Name, PortType, State, Status, IoNumber);
        Apply(e);
        RegisterEvent(e);
    }
    public long OrganizationId { get; private set; }
    [ForeignKey("Controller")]
    public long ControllerId { get; private set; }
    public virtual Controller Controller { get; set; } = default!;
    public string Name { get; private set; } = default!;
    public PortType PortType { get; private set; }
    public State State { get; private set; }
    public string? Status { get; private set; }
    public int IONumber { get; private set; }


}
