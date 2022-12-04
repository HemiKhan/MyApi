namespace Application.Specifications;

using System.Linq.Expressions;

using Application.Specifications.Base;
using Domain.Models.ControllerModels;
using Domain.Models.ControllerModels.DoorModels;
using Domain.Models.QUserModels;
using SharedKernel.Interfaces;

using Microsoft.EntityFrameworkCore;

internal static partial class Specs
{

    internal static class Common
    {
        internal static GenericQSpec<TEntity> GetById<TEntity, TId>(TId id) where TEntity : class, IEntity
        => new()
        {
            SpecificationFunc = _ => _.Where(id)
        };

        internal static GenericQSpec<TEntity, TResponse> GetById<TEntity, TResponse>(long id, Expression<Func<TEntity, TResponse>> selectExpression) where TEntity : class, IEntity
        => new()
        {
            SpecificationFunc = _ => _.Where(id).Select(selectExpression)
        };

        internal static GenericQSpec<TEntity> GetByIdWithInclude<TEntity, TIncludeProperty>(long id, Expression<Func<TEntity, IEnumerable<TIncludeProperty>>> includeExpression) where TEntity : class, IEntity => new()
        {
            SpecificationFunc = _ => _.Include(includeExpression).Where(id)
        };
        internal static GenericQSpec<TEntity> GetByColumn<TEntity>(string columnName, object value) where TEntity : class, IEntity
        => new()
        {
            SpecificationFunc = _ => _.Where(columnName, value)
        };

        internal static GenericQSpec<TEntity, TResponse> GetById<TEntity, TResponse, TValue>(string columnName, TValue value, Expression<Func<TEntity, TResponse>> selectExpression) where TEntity : class, IEntity
        => new()
        {
            SpecificationFunc = _ => _.Where(columnName, value).Select(selectExpression)
        };
    }

    internal static class ControllerSpecs
    {
        public static GenericQSpec<Controller> CheckNameAlreadyExists(long Id, string Name) => new()
        {
            SpecificationFunc = _ =>
            _.Where(_ => _.Name == Name && _.Id != Id)
        };

    }
    internal static class DoorSpecs
    {
        internal static GenericQSpec<Door, object> GetDoorerById(int Id) =>
         new()
         {
             SpecificationFunc = _ => _.Select(o => new { o.Id, o.Name }).Where(_ => _.Id == Id)
         };



        public static GenericQSpec<Door> GetDoor(long id) => new()
        {
            SpecificationFunc = _ =>
            _.Where(_ => _.Id == id)
           .Include(_=>_.Readers)
            .ThenInclude(_ => _.ReaderIdentificationType)
            .Include(_ => _.DoorAdvanceConfiguration)
             .Include(_ => _.Rexes)


        };
    }

    internal static class QUserSpecs
    {
        internal static GenericQSpec<QUser> GetQUser(long id) => new GenericQSpec<QUser>()
        {

            SpecificationFunc = _ => _.Where(x => x.Id == id)
            .Include(c => c.Cards)
            .Include(a => a.QUserAccessLevels)
            .Include(f => f.QUserFiles)
        };
    }

}
