using Microsoft.Extensions.DependencyInjection;

namespace NSolve.Infrastructure.CQRS.Commands;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : CommandBase
    {
        _ = command ?? throw new ArgumentNullException(nameof(command));

        await using var scope = _serviceProvider.CreateAsyncScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.HandleAsync(command, cancellationToken);
    }
}