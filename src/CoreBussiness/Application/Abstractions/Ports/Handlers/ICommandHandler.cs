using Application.Abstractions.Contracts;

namespace Application.Abstractions.Ports.Handlers;
public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task Handle(TCommand command, CancellationToken cancellationToken);
}
