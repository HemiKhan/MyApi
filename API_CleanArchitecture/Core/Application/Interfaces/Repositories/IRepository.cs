namespace Application.Interfaces.Repositories;

using System.Collections.Generic;

using Application.Exceptions;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Behaviours.ControllerBehaviours.Base;
using SharedKernel.Interfaces;

using Microsoft.EntityFrameworkCore;

public interface IRepositoryBase
{
    DbContext DbContext { get; }
}

public interface IReadRepository : IRepositoryBase
{

    /// <summary>
    /// Filters the entities  of <typeparamref name="T"/>, to those that match the encapsulated query logic of the
    /// <paramref name="specification"/>.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <returns>The filtered entities as an <see cref="IQueryable{T}"/>.</returns>
    protected virtual IQueryable<TEntity> ApplySpecification<TEntity>(IQSpecification<TEntity> specification, bool evaluateCriteriaOnly = false) where TEntity : class, IAggregateRoot
    {
        return specification.AsQueryable(DbContext.Set<TEntity>());
    }

    /// <summary>
    /// Filters all entities of <typeparamref name="T" />, that matches the encapsulated query logic of the
    /// <paramref name="specification"/>, from the database.
    /// <para>
    /// Projects each entity into a new form, being <typeparamref name="TResult" />.
    /// </para>
    /// </summary>
    /// <typeparam name="TResult">The type of the value returned by the projection.</typeparam>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <returns>The filtered projected entities as an <see cref="IQueryable{T}"/>.</returns>
    protected virtual IQueryable<TResult> ApplySpecification<TEntity, TResult>(IQSpecification<TEntity, TResult> specification) where TEntity : class, IAggregateRoot
    {
        return specification.AsQueryable(DbContext.Set<TEntity>());
    }

    /// <summary>
    /// Finds an entity with the given primary key value.
    /// </summary>
    /// <typeparam name="TId">The type of primary key.</typeparam>
    /// <param name="id">The value of the primary key for the entity to be found.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the <typeparamref name="TEntity" />, or <see langword="null"/>.
    /// </returns>
    async ValueTask<QResult<TEntity?>> GetByIdAsync<TEntity, TId>(TId id, CancellationToken cancellationToken = default, bool throwOnNotFoundException = true, bool throwOnAlreadyExist = false) where TEntity : class, IAggregateRoot where TId : notnull
    {
        try
        {
            var result = await DbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
            if (throwOnNotFoundException && result is null)
                return RepositoryExceptions.NotFoundException<TEntity>();
            if (throwOnAlreadyExist && result is not null)
                return RepositoryExceptions.AlreadyExistException<TEntity>();
            return result;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the <typeparamref name="TEntity" />, or <see langword="null"/>.
    /// </returns>
    async Task<QResult<TEntity?>> FirstOrDefaultAsync<TEntity>(IQSpecification<TEntity> specification, CancellationToken cancellationToken = default, bool throwOnNotFoundException = true, bool throwOnAlreadyExist = false) where TEntity : class, IAggregateRoot
    {
        try
        {
            var result = await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);

            if (throwOnNotFoundException && result is null)
                return RepositoryExceptions.NotFoundException<TEntity>();
            if (throwOnAlreadyExist && result is not null)
                return RepositoryExceptions.AlreadyExistException<TEntity>();
            return result;
        }
        catch (Exception ex)
        {

            return ex;
        }
    }

    /// <summary>
    /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the <typeparamref name="TResult" />, or <see langword="null"/>.
    /// </returns>
    async Task<QResult<TResult?>> FirstOrDefaultAsync<TEntity, TResult>(IQSpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default, bool throwOnNotFoundException = true, bool throwOnAlreadyExist = false) where TEntity : class, IAggregateRoot
    {
        try
        {
            var result = await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);

            if (throwOnNotFoundException && result is null)
                return RepositoryExceptions.NotFoundException<TEntity>();
            if (throwOnAlreadyExist && result is not null)
                return RepositoryExceptions.AlreadyExistException<TEntity>();
            return result;
        }
        catch (Exception ex)
        {

            return ex;
        }
    }

    /// <summary>
    /// Returns the only element of a sequence, or a default value if the sequence is empty; this method throws an exception if there is more than one element in the sequence.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the <typeparamref name="TEntity" />, or <see langword="null"/>.
    /// </returns>
    async Task<QResult<TEntity?>> SingleOrDefaultAsync<TEntity>(IQSpecification<TEntity> specification, CancellationToken cancellationToken = default, bool throwOnNotFoundException = true, bool throwOnAlreadyExist = false) where TEntity : class, IAggregateRoot
    {
        try
        {
            var result = await ApplySpecification(specification).SingleOrDefaultAsync(cancellationToken);
            if (throwOnNotFoundException && result is null)
                return RepositoryExceptions.NotFoundException<TEntity>();
            if (throwOnAlreadyExist && result is not null)
                return RepositoryExceptions.AlreadyExistException<TEntity>();
            return result;
        }
        catch (Exception ex)
        {

            return ex;
        }
    }

    /// <summary>
    /// Returns the only element of a sequence, or a default value if the sequence is empty; this method throws an exception if there is more than one element in the sequence.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the <typeparamref name="TResult" />, or <see langword="null"/>.
    /// </returns>
    async Task<QResult<TResult?>> SingleOrDefaultAsync<TEntity, TResult>(IQSpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default, bool throwOnNotFoundException = true, bool throwOnAlreadyExist = false) where TEntity : class, IAggregateRoot
    {
        try
        {
            var result = await ApplySpecification(specification).SingleOrDefaultAsync(cancellationToken);

            if (throwOnNotFoundException && result is null)
                return RepositoryExceptions.NotFoundException<TEntity>();
            if (throwOnAlreadyExist && result is not null)
                return RepositoryExceptions.AlreadyExistException<TEntity>();
            return result;
        }
        catch (Exception ex)
        {

            return ex;
        }
    }

    /// <summary>
    /// Finds all entities of <typeparamref name="TEntity" /> from the database.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="List{TEntity}" /> that contains elements from the input sequence.
    /// </returns>
    async Task<QResult<IEnumerable<TEntity>?>> GetAllAsync<TEntity>(CancellationToken cancellationToken = default, bool throwOnNotFoundException = true, bool throwOnAlreadyExist = false) where TEntity : class, IAggregateRoot
    {
        try
        {
            var result = await DbContext.Set<TEntity>().ToListAsync(cancellationToken);

            if (throwOnNotFoundException && result is null)
                return RepositoryExceptions.NotFoundException<TEntity>();
            if (throwOnAlreadyExist && result is not null)
                return RepositoryExceptions.AlreadyExistException<TEntity>();
            return result;
        }
        catch (Exception ex)
        {

            return ex;
        }
    }

    /// <summary>
    /// Finds all entities of <typeparamref name="TEntity" />, that matches the encapsulated query logic of the
    /// <paramref name="specification"/>, from the database.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="List{TEntity}" /> that contains elements from the input sequence.
    /// </returns>
    async Task<QResult<IEnumerable<TEntity>?>> GetAllAsync<TEntity>(IQSpecification<TEntity> specification, CancellationToken cancellationToken = default, bool throwOnNotFoundException = true, bool throwOnAlreadyExist = false) where TEntity : class, IAggregateRoot
    {
        try
        {
            var result = await ApplySpecification(specification).ToListAsync(cancellationToken);

            //    return specification.PostProcessingAction == null ? queryResult : specification.PostProcessingAction(queryResult).ToList();
            if (throwOnNotFoundException && result is null)
                return RepositoryExceptions.NotFoundException<TEntity>();
            if (throwOnAlreadyExist && result is not null)
                return RepositoryExceptions.AlreadyExistException<TEntity>();
            return result;
        }
        catch (Exception ex)
        {

            return ex;
        }
    }

    /// <summary>
    /// Finds all entities of <typeparamref name="TEntity" />, that matches the encapsulated query logic of the
    /// <paramref name="specification"/>, from the database.
    /// <para>
    /// Projects each entity into a new form, being <typeparamref name="TResult" />.
    /// </para>
    /// </summary>
    /// <typeparam name="TResult">The type of the value returned by the projection.</typeparam>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="List{TResult}" /> that contains elements from the input sequence.
    /// </returns>
    async Task<QResult<IEnumerable<TResult>?>> GetAllAsync<TEntity, TResult>(IQSpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default, bool throwOnNotFoundException = true, bool throwOnAlreadyExist = false) where TEntity : class, IAggregateRoot
    {
        try
        {
            var result = await ApplySpecification(specification).ToListAsync(cancellationToken);

            if (throwOnNotFoundException && result is null)
                return RepositoryExceptions.NotFoundException<TEntity>();
            if (throwOnAlreadyExist && result is not null)
                return RepositoryExceptions.AlreadyExistException<TEntity>();
            return result;
        }
        catch (Exception ex)
        {

            return ex;
        }
    }

    /// <summary>
    /// Returns a number that represents how many entities satisfy the encapsulated query logic
    /// of the <paramref name="specification"/>.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the
    /// number of elements in the input sequence.
    /// </returns>
    async Task<QResult<int?>> CountAsync<TEntity>(IQSpecification<TEntity> specification, CancellationToken cancellationToken = default) where TEntity : class, IAggregateRoot
    {
        try
        {
            return await ApplySpecification(specification, true).CountAsync(cancellationToken);
        }
        catch (Exception ex)
        {

            return ex;
        }
    }

    /// <summary>
    /// Returns the total number of records.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the
    /// number of elements in the input sequence.
    /// </returns>
    async Task<QResult<int?>> CountAsync<TEntity>(CancellationToken cancellationToken = default) where TEntity : class, IAggregateRoot
    {
        try
        {
            return await DbContext.Set<TEntity>().CountAsync(cancellationToken);
        }
        catch (Exception ex)
        {

            return ex;
        }
    }

    /// <summary>
    /// Returns a boolean that represents whether any entity satisfy the encapsulated query logic
    /// of the <paramref name="specification"/> or not.
    /// </summary>
    /// <param name="specification">The encapsulated query logic.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains true if the 
    /// source sequence contains any elements; otherwise, false.
    /// </returns>
    async Task<QResult<bool?>> AnyAsync<TEntity>(IQSpecification<TEntity> specification, CancellationToken cancellationToken = default, bool throwOnNotFoundException = true, bool throwOnAlreadyExist = false) where TEntity : class, IAggregateRoot
    {
        try
        {
            var result = await ApplySpecification(specification, true).AnyAsync(cancellationToken);
            if (throwOnNotFoundException && result is false)
                return RepositoryExceptions.NotFoundException<TEntity>();
            if (throwOnAlreadyExist && result is true)
                return RepositoryExceptions.AlreadyExistException<TEntity>();
            return result;
        }
        catch (Exception ex)
        {

            return ex;
        }
    }

    /// <summary>
    /// Returns a boolean whether any entity exists or not.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains true if the 
    /// source sequence contains any elements; otherwise, false.
    /// </returns>
    async Task<QResult<bool?>> AnyAsync<TEntity>(CancellationToken cancellationToken = default, bool throwOnNotFoundException = true, bool throwOnAlreadyExist = false) where TEntity : class, IAggregateRoot
    {
        try
        {
            var result = await DbContext.Set<TEntity>().AnyAsync(cancellationToken);
            if (throwOnNotFoundException && result is false)
                return RepositoryExceptions.NotFoundException<TEntity>();

            if (throwOnAlreadyExist && result is true)
                return RepositoryExceptions.AlreadyExistException<TEntity>();

            return result;
        }
        catch (Exception ex)
        {

            return ex;
        }
    }
}




/// <summary>
/// <para>
/// A <see cref="IRepositoryBase{TEntity}" /> can be used to query and save instances of <typeparamref name="TEntity" />.
/// An <see cref="IQSpecification{TEntity}"/> (or derived) is used to encapsulate the LINQ queries against the database.
/// </para>
/// </summary>
/// <typeparam name="TEntity">The type of entity being operated on by this repository.</typeparam>
public interface IWriteRepository : IRepositoryBase
{

    async Task<QResult<TEntity?>> EnableChangeTracker<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot
    {
        try
        {
            DbContext.Attach(entity);
            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// Adds an entity in the database.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the <typeparamref name="TEntity" />.
    /// </returns>
    async Task<QResult<TEntity?>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default, bool autoSave = true) where TEntity : class, IAggregateRoot
    {
        try
        {
            DbContext.Set<TEntity>().Add(entity);
            if (autoSave)
            {
                var SaveChangesResult = await SaveChangesAsync(cancellationToken);

                if (SaveChangesResult.Status is Status.Exception)
                    return SaveChangesResult.Exception!;
            }
            return entity;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// Adds the given entities in the database
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the <typeparamref name="IEnumerable<TEntity>" />.
    /// </returns>
    async Task<QResult<IEnumerable<TEntity>?>> AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default, bool autoSave = true) where TEntity : class, IAggregateRoot
    {
        try
        {
            DbContext.Set<TEntity>().AddRange(entities);

            if (autoSave)
            {
                var SaveChangesResult = await SaveChangesAsync(cancellationToken);

                if (SaveChangesResult.Status is Status.Exception)
                    return SaveChangesResult.Exception!;
            }

            return await Task.FromResult(QResults.From(entities));
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// Updates an entity in the database
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    async Task<QResult<TEntity?>> UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default, bool autoSave = true) where TEntity : class, IAggregateRoot
    {
        try
        {


            DbContext.Set<TEntity>().Update(entity);

            if (autoSave)
            {
                var SaveChangesResult = await SaveChangesAsync(cancellationToken);

                if (SaveChangesResult.Status is Status.Exception)
                    return SaveChangesResult.Exception!;
            }
            return entity;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// Updates the given entities in the database
    /// </summary>
    /// <param name="entities">The entities to update.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    async Task<QResult<IEnumerable<TEntity>?>> UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default, bool autoSave = true) where TEntity : class, IAggregateRoot
    {
        try
        {


            DbContext.Set<TEntity>().UpdateRange(entities);

            if (autoSave)
            {
                var SaveChangesResult = await SaveChangesAsync(cancellationToken);

                if (SaveChangesResult.Status is Status.Exception)
                    return SaveChangesResult.Exception!;
            }
            return await Task.FromResult(QResults.From(entities));
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// Removes an entity in the database
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    async Task<QResult<TEntity?>> DeleteAsync<TEntity>(IDeleted<TEntity> deletedEntity, CancellationToken cancellationToken = default, bool autoSave = true) where TEntity : class, IAggregateRoot
    {
        try
        {


            DbContext.Entry(deletedEntity.Entity).State = EntityState.Deleted;

            //DbContext.Set<TEntity>().Remove(deletedEntity.Entity);
            if (autoSave)
            {
                var SaveChangesResult = await SaveChangesAsync(cancellationToken);

                if (SaveChangesResult.Status is Status.Exception)
                    return SaveChangesResult.Exception!;
            }
            return deletedEntity.Entity;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

   

    /// <summary>
    /// Removes the given entities in the database
    /// </summary>
    /// <param name="entities">The entities to remove.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    async Task<QResult<IEnumerable<TEntity>?>> DeleteRangeAsync<TEntity>(IEnumerable<IDeleted<TEntity>> deletedEntities, CancellationToken cancellationToken = default, bool autoSave = true) where TEntity : class, IAggregateRoot
    {
        try
        {
            var entities = deletedEntities.Select(_ => _.Entity);
            DbContext.Set<TEntity>().RemoveRange();

            if (autoSave)
            {
                var SaveChangesResult = await SaveChangesAsync(cancellationToken);

                if (SaveChangesResult.Status is Status.Exception)
                    return SaveChangesResult.Exception!;
            }
            return await Task.FromResult(QResults.From(entities));
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// Persists changes to the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    async Task<QResult<int?>> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}


public interface IRepository : IReadRepository, IWriteRepository
{
    public virtual async Task<QResult<TEntity?>> DeleteIfAnyElseThrowAsync<TEntity, TId>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IAggregateRoot<TId>
    {
        try
        {

            var hasAnyEntityResult = await AnyAsync(
                Specs.Common.GetById<TEntity, TId>(entity.Id), cancellationToken);

            if (hasAnyEntityResult.Status is Status.Exception)
                return hasAnyEntityResult.Exception!;

            DbContext.Entry(entity).State = EntityState.Deleted;

            //DbContext.Set<TEntity>().Remove(entity);

            var SaveChangesResult = await SaveChangesAsync(cancellationToken);

            if (SaveChangesResult.Status is Status.Exception)
                return SaveChangesResult.Exception!;

            return entity;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
