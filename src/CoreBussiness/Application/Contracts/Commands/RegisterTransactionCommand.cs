
using Application.Abstractions.Contracts;

namespace Application.Contracts.Commands;
public record RegisterTransactionCommand(string Category, DateTime CreateAt, string Daescription, decimal Value)
    : Message, ICommand
{
}
