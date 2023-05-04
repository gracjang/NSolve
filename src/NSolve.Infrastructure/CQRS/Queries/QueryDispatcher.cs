using Microsoft.Extensions.DependencyInjection;

namespace NSolve.Infrastructure.CQRS.Queries;

internal sealed class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> QueryAsync<TResult>(QueryBase<TResult> query, CancellationToken cancellationToken = default) where TResult : class
    {
        _ = query ?? throw new ArgumentNullException(nameof(query));

        await using var scope = _serviceProvider.CreateAsyncScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);
        var method = handlerType.GetMethod(nameof(IQueryHandler<QueryBase<TResult>, TResult>.HandleAsync)) ??
                     throw new InvalidOperationException($"Query handler for '{typeof(TResult).Name}' is invalid.");

        return await (Task<TResult>)method!.Invoke(handler, new object[] { query, cancellationToken })!;
    }
}