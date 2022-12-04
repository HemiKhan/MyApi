namespace Domain.Dtos;

public record AddAreaDto(string Name, bool IsEntrance);
public record UpdateAreaDto(long Id, string Name, bool IsEntrance);
public record GetAreaByIdDto(long Id, string Name, bool IsEntrance);
public record GetAllAreasDto(long Id, string Name, bool IsEntrance);