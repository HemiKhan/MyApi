namespace Application.Exceptions;
internal static class RepositoryExceptions
{
    public static QException NotFoundException<TEntity>() => new QException(typeof(TEntity).Name + QMessages.CommonMessages.NotFound);
    public static QException AlreadyExistException<TEntity>() => new QException(typeof(TEntity).Name + QMessages.CommonMessages.AlreadyExist);
}
