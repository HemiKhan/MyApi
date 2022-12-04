namespace Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record ControllerIoPorts_Added(long Id, long ControllerId, string Name, PortType PortType, State State, string Status, int IoNumber) : IDomainEvent;
public record ControllerIoPorts_Updated(long Id, ControllerIoPorts_Updated_Event Old, ControllerIoPorts_Updated_Event New) : IDomainEvent;
public class ControllerIoPorts_Updated_Event
{
    public long Id { get; set; }
    public long ControllerId { get; set; }
    public PortType PortType { get; set; } = default!;
    public string Name { get; set; } = default!;
    public State State { get; set; } = default!;
    public string Status { get; set; } = default!;
    public int IONumber { get; set; }
}