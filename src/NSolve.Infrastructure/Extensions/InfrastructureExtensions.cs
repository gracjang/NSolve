
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSolve.Infrastructure.CQRS;
using NSolve.Infrastructure.CQRS.Commands;
using NSolve.Infrastructure.CQRS.Queries;
using NSolve.Infrastructure.DAL;

namespace NSolve.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Scan(s => s.FromAssemblies(typeof(ICommandHandler<>).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(s => s.FromAssemblies(typeof(IQueryHandler<,>).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddDbContext<SolveDbContext>(
            options => options.UseSqlServer(configuration.GetRequiredSection("DbConnectionString").Value));

        services.AddSingleton<IDispatcher, Dispatcher>();

        return services;
    }
}