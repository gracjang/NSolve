using NSolve.Infrastructure.CQRS.Commands;
using NSolve.Infrastructure.CQRS.Queries;

namespace NSolve.Infrastructure.CQRS;

public class Dispatcher : IDispatcher
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public Dispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    public async Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : CommandBase
        => await _commandDispatcher.SendAsync(command, cancellationToken);

    public Task<TResult> QueryAsync<TResult>(QueryBase<TResult> query, CancellationToken cancellationToken = default) where TResult : class
        => _queryDispatcher.QueryAsync(query, cancellationToken);
}