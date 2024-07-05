namespace Application.Abstractions.Contracts;

public abstract class Message : ICommand
{
    public DateTimeOffset TimeStamp { get; private set; } = DateTimeOffset.UtcNow;
}
