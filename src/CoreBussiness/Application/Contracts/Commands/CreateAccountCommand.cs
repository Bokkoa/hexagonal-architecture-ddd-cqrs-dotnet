using Application.Abstractions.Contracts;

namespace Application.Contracts.Commands;
public record CreateAccountCommand(string FirstName, string LastName, string Email) : Message, ICommand
{
}
