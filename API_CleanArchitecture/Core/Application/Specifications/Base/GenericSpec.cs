namespace Application.Specifications.Base;

using System;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using SharedKernel.Interfaces;

internal class GenericQSpec<T> : IQSpecification<T> where T : class, IEntity
{
    public Func<IQueryable<T>, IQueryable<T>> SpecificationFunc { get; init; } = default!;
}
internal class GenericQSpec<T, TResponse> : IQSpecification<T, TResponse> where T : class, IEntity
{
    public Func<IQueryable<T>, IQueryable<TResponse>> SpecificationFunc { get; init; } = default!;
}


public class GenericDSpec<T> : IDSpecification<T>
{
    public string CommandText { get; init; } = default!;

    public object Parameters { get; init; } = default!;

    public CommandType CommandType { get; init; } = CommandType.StoredProcedure;
}
