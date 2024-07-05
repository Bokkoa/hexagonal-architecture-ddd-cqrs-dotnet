using System.Windows.Input;

namespace Application.Abstractions.Handlers;

public abstract class CommandHandler<TCommand> where TCommand : ICommand {
    public abstract Task Handle(TCommand command, CancellationToken cancellationToken);
}
