using Application.Abstractions.Contracts;

namespace Application.Contracts.Commands;
public record RegisterBudgetCommand (Guid AccountId, DateOnly ReferencePeriod, decimal TotalValue)
    : Message, ICommand
{
}
