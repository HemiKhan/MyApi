namespace Application.Specifications.Base;

using System.Linq;

using SharedKernel.Interfaces;

using Microsoft.EntityFrameworkCore;

public interface IQSpecification<TEntity> where TEntity : class, IEntity
{

    Func<IQueryable<TEntity>, IQueryable<TEntity>> SpecificationFunc { get; }

    public IQueryable<TEntity> AsQueryable(IQueryable<TEntity> Query)
    {
        Query = Query.AsNoTracking();
        return SpecificationFunc(Query);
    }


}


public interface IQSpecification<TEntity, TResult> where TEntity : class, IEntity
{
    Func<IQueryable<TEntity>, IQueryable<TResult>> SpecificationFunc { get; }


    public IQueryable<TResult> AsQueryable(IQueryable<TEntity> Query)
    {
        Query = Query.AsNoTracking();
        return SpecificationFunc(Query);
    }
}