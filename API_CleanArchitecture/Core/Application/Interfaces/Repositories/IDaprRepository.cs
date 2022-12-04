namespace Application.Interfaces.Repositories;

using System.Data.Common;

using Application.Exceptions;
using Application.Specifications.Base;
using SharedKernel.Interfaces;

using Dapper;

using Humanizer;

public interface IDapperRepository
{
    DbConnection GetConnection();

    /// <summary>
    /// Filters the entities  of <typeparamref name="TEntity"/>, to those that match the encapsulated query logic of the
    /// <paramref name="specification"/>.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <returns>The filtered entities as an <see cref="IQueryable{TEntity}"/>.</returns>
    protected virtual CommandDefinition ApplySpecification<TEntity>(IDSpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return specification.AsCommandDefination(cancellationToken);
    }

    public async Task<QResult<IEnumerable<TEntity>?>> QueryAsync<TEntity>(IDSpecification<TEntity> specification, bool throwOnNotFoundException = true, CancellationToken cancellationToken = default)
    {
        using var con = GetConnection();
        con.Open();
        var result = await con.QueryAsync<TEntity>(ApplySpecification(specification, cancellationToken));
        if (throwOnNotFoundException && (result is null || !result.Any()))
            return RepositoryExceptions.NotFoundException<TEntity>();
        return QResults.From(result);
    }

    public async Task<QResult<TEntity?>> QueryFirstOrDefaultAsync<TEntity>(IDSpecification<TEntity> specification, bool throwOnNotFoundException = true, CancellationToken cancellationToken = default)
    {
        using var con = GetConnection();
        var result = await con.QueryFirstOrDefaultAsync<TEntity>(ApplySpecification(specification, cancellationToken));
        if (throwOnNotFoundException && result is null)
            return RepositoryExceptions.NotFoundException<TEntity>();
        return result;
    }

    public async Task<QResult<TEntity?>> QuerySingleOrDefaultAsync<TEntity>(IDSpecification<TEntity> specification, bool throwOnNotFoundException = true, CancellationToken cancellationToken = default)
    {
        using var con = GetConnection();
        con.Open();
        var result = await con.QuerySingleOrDefaultAsync<TEntity>(ApplySpecification(specification, cancellationToken));
        if (throwOnNotFoundException && result is null)
            return RepositoryExceptions.NotFoundException<TEntity>();
        return result;
    }


    public async Task<QResult<SqlMapper.GridReader?>> QueryMultipleAsync<TEntity>(IDSpecification<TEntity> specification, bool throwOnNotFoundException = true, CancellationToken cancellationToken = default)
    {
        using var con = GetConnection();
        con.Open();
        var result = await con.QueryMultipleAsync(ApplySpecification(specification, cancellationToken));
        if (throwOnNotFoundException && result is null)
            return RepositoryExceptions.NotFoundException<TEntity>();
        return result;
    }





    public async Task<QResult<TEntity?>> ExecuteScalarAsync<TEntity>(IDSpecification<TEntity> specification, bool throwOnNotFoundException = true, CancellationToken cancellationToken = default)
    {
        using var con = GetConnection();
        con.Open();
        var result = await con.ExecuteScalarAsync<TEntity>(ApplySpecification(specification, cancellationToken));
        if (throwOnNotFoundException && result is null)
            return RepositoryExceptions.NotFoundException<TEntity>();
        return result;

    }





    public async Task<QResult<TId?>> DeleteAsync<TEntity, TId>(IDSpecification<TEntity> specification, bool validateBeforeExecution = true, CancellationToken cancellationToken = default) where TEntity : class, IEntity<TId>
    {
        using var con = GetConnection();
        con.Open();
        await con.ExecuteAsync(ApplySpecification(specification, cancellationToken));

        var pram = specification.Parameters as DynamicParameters;
        if (validateBeforeExecution)
        {
            var message_Response = pram!.Get<string>("@return_Message");
            if (message_Response is not "OK")
            {
                var entity = message_Response.Split('.');
                entity[0] = entity[0].Singularize();

                throw new QException(string.Join('.', entity).Singularize());
            }
        }
        return pram!.Get<TId>("@id");
    }


}
