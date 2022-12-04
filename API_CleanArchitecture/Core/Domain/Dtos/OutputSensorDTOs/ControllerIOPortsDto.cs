namespace Domain.Dtos.OutputSensorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record Update_ControllerIoPorts_Dto(long Id, long ControllerId, PortType PortType, string Name, State State, string? Status, int IONumber);
public record GetAll_Controllers_Dto(long Id, string Name);