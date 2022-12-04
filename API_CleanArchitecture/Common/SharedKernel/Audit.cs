namespace SharedKernel;

public record Audit
{
    public Audit() { }

    /// <summary>
    /// Operator Name
    /// </summary>
    public string Operator { get; set; } = string.Empty;

    /// <summary>
    /// Operator IP
    /// </summary>
    public string IPAddress { get; set; } = string.Empty;

    public long OrganizationId { get; set; }
    public DateTime CreatedDate { get; set; }


    public string Module { get; set; } = string.Empty;
    public object Data { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;

}