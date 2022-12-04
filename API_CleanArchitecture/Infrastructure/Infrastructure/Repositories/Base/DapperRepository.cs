namespace Infrastructure.Repositories.Base;

using System.Data.Common;

using Application.Interfaces;
using Application.Interfaces.Repositories;

using Microsoft.Data.SqlClient;



internal class DapperRepository : IDapperRepository
{
	private readonly IDbConnection _dbConnection;

	public DapperRepository(IDbConnection dbConnection)
	{
		_dbConnection = dbConnection;
	}

	public DbConnection GetConnection()
	{
		var con = new SqlConnection(_dbConnection.CS);
		return con;
	}
}
