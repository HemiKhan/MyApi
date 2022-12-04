namespace Application.Common;

using Application.Interfaces;

using Microsoft.Extensions.Options;



public class ConnectionStringsOption
{
    public const string SectionName = "ConnectionStrings";
    public string DefaultConnection { get; set; } = "";
    public string CS => DefaultConnection;

}


public class DBConnection : IDbConnection
{
    private string _connection = "";
    public DBConnection(IOptions<ConnectionStringsOption> options)
    {
        _connection = options.Value.CS;
        // _connection = "SERVER=" + "SYNERGY-SD" + ";" + "DATABASE=" + "AxisController" + ";" + "UID=" + "sa" + ";" + "PASSWORD=" + "DB2axxess" + ";MultipleActiveResultSets=true;";
    }

    public string CS
    {
        get { return _connection; }
        set { _connection = value; }
    }
}