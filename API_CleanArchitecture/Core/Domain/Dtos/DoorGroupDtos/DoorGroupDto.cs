namespace Domain.Dtos.DoorGroupDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record AddDoorGroupDto(string Name, IEnumerable<long> DoorId);
public record UpdateDoorGroupDto(long Id, string Name, IEnumerable<DGDDto> DGD);
public record GetByIdDoorGroupDto(long Id, string Name, IEnumerable<DGDDto> DGD);
public record AddDoorGroupDoorDto(long DoorGroupId, IEnumerable<long> DoorId);
public record DGDDto(long? Id, long DoorId);
public record GetAllDoorGroupDto(long Id, string Name);