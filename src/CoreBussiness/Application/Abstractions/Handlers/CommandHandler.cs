using Application.Abstractions.Contracts;
using Application.Abstractions.Ports.Handlers;

namespace Application.Abstractions.Handlers;

public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
{
    public abstract Task Handle(TCommand command, CancellationToken cancellationToken);
}
