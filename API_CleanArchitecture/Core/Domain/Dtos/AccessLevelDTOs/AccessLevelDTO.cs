namespace Domain.Dtos.AccessLevelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public record Add_AccessLevel_DTO
    (
    string Name,
    long ScheduleId,
    long? ExceptScheduleId,
    Add_AccessLevelDoor_DTO[] AccessLevelDoors
    )
{ }

public record Update_AccessLevel_DTO
    (
    long Id,
    string Name,
    long ScheduleId,
    long? ExceptScheduleId,
    Update_AccessLevelDoor_DTO[] AccessLevelDoors
    )
{ }


public record GetById_AccessLevel_DTO
    (
    long Id,
    string Name,
    long ScheduleId,
    long? ExceptScheduleId,
   List<GetAll_AccessLevelDoor_DTO> AccessLevelDoors
    )
{ }


public record GetAll_AccessLevel_DTO
    (
    long Id,
    string Name
    )
{ }


public record Update_AccessLevel_Parameters
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    public long ScheduleId { get; set; }
    public long? ExceptScheduleId { get; set; }
    public List<Update_AccessLevelDoor_DTO> AccessLevelDoors { get; set; } = new();
}


public record Delete_AccessLevel_DTO(long Id) { }