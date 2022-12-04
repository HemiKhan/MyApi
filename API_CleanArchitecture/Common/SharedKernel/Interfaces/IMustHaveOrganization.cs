namespace SharedKernel.Interfaces;
/// <summary>
/// Base Interface for the Entities that have Organization Id.
/// You Just Have to Inherit This Interface, the Generation of Id Will be Managed Automatically
/// </summary>
public interface IMustHaveOrganization
{
    long OrganizationId { get; }
}
