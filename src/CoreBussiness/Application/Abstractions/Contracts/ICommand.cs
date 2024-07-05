

namespace Application.Abstractions.Contracts;

public interface ICommand
{
    DateTimeOffset TimeStamp { get; }
}
