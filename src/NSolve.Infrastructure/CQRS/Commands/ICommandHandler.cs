namespace NSolve.Infrastructure.CQRS.Commands;

public interface ICommandHandler<in T> where T : CommandBase
{
    Task HandleAsync(T command, CancellationToken cancellationToken = default);
}