namespace Domain.Models.OutputSensorModel;

using Domain.Dtos;
using Domain.Dtos.CardFormatDtos;
using Domain.Dtos.OutputSensorDTOs;
using Domain.Events;
using Domain.Events.ScheduleEvents;
using Domain.Models.CardFormatsModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record ControllerIOPorts
{
    public static ControllerIOPorts Create(Update_ControllerIoPorts_Dto cmd) => new ControllerIOPorts(
       cmd.Id,
        cmd.ControllerId,
        cmd.Name,
        cmd.PortType,
        cmd.State,
        cmd.Status,
        cmd.IONumber
                      );
    public void UpdateControllerIOPorts(Update_ControllerIoPorts_Dto c)
    {
        var oldValue = new ControllerIoPorts_Updated_Event();
        var newValue = new ControllerIoPorts_Updated_Event();
        if (!PortType.Equals(c.PortType))
        {
            oldValue.PortType = PortType;
            newValue.PortType = c.PortType;
        }
        if (!Name.Equals(c.Name))
        {
            oldValue.Name = Name;
            newValue.Name = c.Name;
        }
        if (!State.Equals(c.State))
        {
            oldValue.State = State;
            newValue.State = c.State;
        }
        if (!Status.Equals(c.Status) && !string.IsNullOrEmpty(c.Status))
        {
            oldValue.Status = Status;
            newValue.Status = c.Status;
        }
        if (!IONumber.Equals(c.IONumber))
        {
            oldValue.IONumber = IONumber;
            newValue.IONumber = c.IONumber;
        }
        if (!ControllerId.Equals(c.ControllerId))
        {
            oldValue.ControllerId = ControllerId;
            newValue.ControllerId = c.ControllerId;
        }
        var e = new ControllerIoPorts_Updated(c.Id, oldValue, newValue);
        RegisterEvent(e);
    }
}
