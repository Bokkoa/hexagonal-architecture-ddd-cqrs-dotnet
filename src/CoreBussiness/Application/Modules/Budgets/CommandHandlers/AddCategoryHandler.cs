using Application.Abstractions.Handlers;
using Application.Abstractions.Ports.Repositories;
using Application.Contracts;
using Domain.Modules.Budgets.Aggregates;
using Domain.Modules.Budgets.ValueObjects.Categories;

namespace Application.Modules.Budgets.CommandHandlers;
public class AddCategoryHandler : CommandHandler<Command.AddCategoryCommand>
{
    private readonly IFinanceManagementRepository _repository;

    public AddCategoryHandler(IFinanceManagementRepository repository)
    {
        _repository = repository;
    }

    public override async Task Handle(Command.AddCategoryCommand command, CancellationToken cancellationToken)
    {
        Budget? budget = await _repository.GetAsync<Budget>(prop => prop.Id == command.BudgetId, cancellationToken);

        if (budget == null) throw new Exception("Budget not found");

        budget.AddCategory(command.Name, command.Limit);

        await _repository.InsertAsync(budget, cancellationToken);
    }
}
