namespace Application.Abstractions.Contracts;

public abstract record Message : ICommand
{
    public DateTimeOffset TimeStamp { get; private set; } = DateTimeOffset.Now;
}
