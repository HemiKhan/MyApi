namespace Domain.Dtos.ControllerDTOs;

using Domain.Helpers;

using Newtonsoft.Json;

public record AddControllerCommand(string Name, string UserName, string Password, string MACAddress, string OAK, bool IsOneDoor, ControllerModel Model);
public record Update_ControllerDTO(long Id, string Name, string UserName, string? Password, string MACAddress, string OAK, bool IsOneDoor, ControllerModel Model);

public record Delete_ControllerDTO(long Id);


public class Get_ControllerDTO
{
    public long Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string UserName { get; init; } = string.Empty;
    public string MACAddress { get; init; } = string.Empty;
    public string OAK { get; init; } = string.Empty;
    public bool IsOneDoor { get; init; }
    public IEnumerable<GetAll_Doors_DTO?> Door { get; set; }
}

public class GetControllerByIdDTO
{
    public long Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string UserName { get; init; } = string.Empty;
    public string MACAddress { get; init; } = string.Empty;
    public string OAK { get; init; } = string.Empty;
    public bool IsOneDoor { get; init; }
    public string State { get; init; } = string.Empty;
    public bool Status { get; set; }
    public bool IsDoor1Added { get; set; }
    public bool IsDoor2Added { get; set; }
    public string Model { get; set; } = string.Empty;
}

public class Get_ControllerIdAndOneDoorConfigDTO
{
    public long Id { get; init; }
    public bool IsOneDoor { get; init; }
}

public class GetAll_Controller_DTO
{
    public long Id { get; init; }
    public string Name { get; init; } = default!;
    public bool Status { get; init; }

    [JsonConverter(typeof(IgnoreEmptyItemsConverter<GetAll_Doors_DTO>))]
    public IEnumerable<GetAll_Doors_DTO> Doors { get; init; } = default!;
}


public record GetAll_Doors_DTO
(
long Id,
string Name,
string DoorType
);

public class GetDoorByControllerIdDTO
{
    public long Id { get; init; }
    public IEnumerable<DoorListByControllerId>? Doors { get; set; }
}
public class DoorListByControllerId
{
    public long DoorId { get; init; }
    public string Name { get; init; } = string.Empty;
}