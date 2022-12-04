namespace Domain.Dtos.AccessLevelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record Add_AccessLevelDoor_Command(long AccessLevelId, long DoorId, long ScheduleId, long? ExceptScheduleId) { }
public record Add_AccessLevelDoor_DTO(long DoorId, long ScheduleId, long? ExceptScheduleId) { }
public record Update_AccessLevelDoor_DTO(long? Id,long DoorId, long ScheduleId, long? ExceptScheduleId) { }
public record GetAll_AccessLevelDoor_DTO(long Id,long DoorId,string Name, long ScheduleId, long? ExceptScheduleId) { }
public class Update_AccessLevelDoor_Parameters
{
    public long? Id { get; set; }
    public long AccessLevelId { get; set; }
    public long DoorId { get; set; }
    public long ScheduleId { get; set; }
    public long? ExceptScheduleId { get; set; }
}


