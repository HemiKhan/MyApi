namespace Domain.Models.OutputSensorModel;

using Domain.Dtos.OutputSensorDTOs;
using Domain.Events;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record ControllerIOPorts
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case ControllerIoPorts_Added e:
                Apply(e);
                break;
            case ControllerIoPorts_Updated e:
                Apply(e);
                break;
        }
    }

    private void Apply(ControllerIoPorts_Added e)
    {

        PortType = e.PortType;
        Name = e.Name;
        State = e.State;
        Status = e.Status;
        IONumber = e.IoNumber;
        ControllerId = e.ControllerId;
    }
    private void Apply(ControllerIoPorts_Updated e)
    {
        if (!Id.Equals(e.Id))
        {
            Id = e.Id;
        }
        if (!PortType.Equals(e.New.PortType))
        {
            PortType = e.New.PortType;
        }
        if (!Name.Equals(e.New.Name) && !string.IsNullOrEmpty(e.New.Name))
        {
            Name = e.New.Name;
        }
        if (!State.Equals(e.New.State))
        {
            State = e.New.State;
        }
        if (!Status.Equals(e.New.Status) && !string.IsNullOrEmpty(e.New.Status))
        {
            Status = e.New.Status;
        }
        if (!IONumber.Equals(e.New.IONumber))
        {
            IONumber = e.New.IONumber;
        }
    }
}
