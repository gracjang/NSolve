using NSolve.Infrastructure.CQRS.Commands;
using NSolve.Infrastructure.CQRS.Queries;

namespace NSolve.Infrastructure.CQRS;

public interface IDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : CommandBase;

    Task<TResult> QueryAsync<TResult>(QueryBase<TResult> query, CancellationToken cancellationToken = default) where TResult : class;
}