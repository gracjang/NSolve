namespace NSolve.Infrastructure.CQRS.Queries;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(QueryBase<TResult> query, CancellationToken cancellationToken = default) where TResult : class;
}