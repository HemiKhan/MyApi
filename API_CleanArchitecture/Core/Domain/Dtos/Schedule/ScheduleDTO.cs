namespace Domain.Dtos;

using Domain.Dtos.ControllerDTOs;
using Domain.Helpers;

using Newtonsoft.Json;

public record AddScheduleDTO(string Name, bool IsSubtraction, string? Description);
public record UpdateScheduleDTO(long Id, string Name, bool IsSubtraction, string? Description);
public record DeleteScheduleDTO(long Id);
public record GetScheduleDTO(long Id, string Name);

public class Get_ScheduleDTO
{

    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public bool IsSubtraction { get; set; }
    [JsonConverter(typeof(IgnoreEmptyItemsConverter<Items>))]
    public IEnumerable<Items>? ScheduleItems { get; init; } = default!;
}

public record Items
(
long Id,
string Summary,
bool IsRecurrence
);