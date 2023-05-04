namespace NSolve.Infrastructure.CQRS.Commands;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : CommandBase;
}