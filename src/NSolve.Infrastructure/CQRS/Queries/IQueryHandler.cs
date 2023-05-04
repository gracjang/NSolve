namespace NSolve.Infrastructure.CQRS.Queries;

public interface IQueryHandler<in TQuery, TResult> where TQuery : QueryBase<TResult> where TResult : class
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}