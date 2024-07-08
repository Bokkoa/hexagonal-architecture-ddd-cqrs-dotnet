using Application.Abstractions.Ports.Handlers;
using Application.Contracts;
using Application.Modules.Accounts.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationLayerDependency
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddTransient<ICommandHandler<Command.CreateAccountCommand>, CreateAccountHandler>();
    }
}
