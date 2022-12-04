namespace Application.Interfaces;
public interface IQClaims
{
    long OrganizationId { get; }
    string Operator { get; }

    string IPAddress { get; }
    string TimeZone { get; }


}
