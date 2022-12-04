namespace Domain.Dtos.ManualControlDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record GetDoorDetailsByIdDtoForManualControl(long Id, string Name, DoorType DoorType, DoorState DoorStatus);
public record AddManualControlDto(ManualCtrlAction Action);