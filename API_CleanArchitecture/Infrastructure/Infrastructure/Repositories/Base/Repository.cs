namespace Infrastructure.Repositories.Base;

using Application.Interfaces.Repositories;
using Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

public class Repository : IRepository
{

    public DbContext DbContext { get; }

    /// <inheritdoc/>
    public Repository(IDbContextFactory<QDbContext> dbContextFactory)
    {
        DbContext = dbContextFactory.CreateDbContext();
    }
}