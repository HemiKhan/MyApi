namespace Domain.Dtos.AccessConfigDTOs;
public record GetByConfigKey_AccessConfigsDTO
{
	public long Id { get; set; }
    public long? ParentId { get; set; }
	public string? ConfigValue { get; set; }
}

public record GetParentIdByConfigKeyDTO
{
    public long Id { get; set; }
}


public record GetByParentIdAccessConfigsDTO
{
    public long Id { get; set; }
    public long ParentId { get; set; }
    public string? ConfigKey { get; set; }
    public string? ConfigValue { get; set; }

}

public record GetByConfigKey_AccessConfig_Request
{
    public string? ConfigKey { get; set; }
}

public record UpdateAccessConfigParameters
{
    public long Id { get; set; }
    public string? ConfigKey { get; set; }
    public string? ConfigValue { get; set; }
    public long ParentId { get; set; }
}


public record UpdateAccessConfigDTO
{
    public string? ConfigKey { get; set; }
    public string? ConfigValue { get; set; }
}
public record GetByParentId_AccessConfigsDTO
{
    public long Id { get; set; }
    public long ParentId { get; set; }
    public string? ConfigKey { get; set; }
    public string? ConfigValue { get; set; }

}

public record UpdateAccessConfigsInBulkCommand
{
    public List<UpdateAccessConfigDTO> AccessConfigs { get; set; } = default!;
}
