using Application.Abstractions.Contracts;

namespace Application.Contracts.Commands;
public record AddCategoryCommand(string Name, decimal Limit)
    :Message, ICommand
{
}
