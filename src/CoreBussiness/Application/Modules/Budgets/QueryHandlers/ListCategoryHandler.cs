using Application.Abstractions.Handlers;
using Application.Abstractions.Ports.Repositories;
using Application.Contracts;

public class ListCategoryHandler : QueryHandler<Query.ListCategoryQuery, List<ViewModel.CategoryViewModel>>
{
    private readonly IFinanceManagementRepository _repository;

    public ListCategoryHandler(IFinanceManagementRepository repository)
    {
        _repository = repository;
    }
    public override async Task<List<ViewModel.CategoryViewModel>> Handle(Query.ListCategoryQuery query, CancellationToken cancellationToken)
    {
        var categories = await _repository.ListAsync<ViewModel.CategoryViewModel>(prop => prop.AccountId == query.AccountId, cancellationToken);
        return categories;
    }
}
