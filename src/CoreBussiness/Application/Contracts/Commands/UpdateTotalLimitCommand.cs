using Application.Abstractions.Contracts;

namespace Application.Contracts.Commands;
public record UpdateTotalLimitCommand(decimal TotalValue) : Message, ICommand
{
}
