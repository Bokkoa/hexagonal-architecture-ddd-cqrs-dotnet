using Domain.Modules.Budgets.Aggregates;
using Domain.Modules.Budgets.ValueObjects.Categories;
using Domain.Modules.Budgets.ValueObjects.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.SqlServer.Databases.Configurations.Budgets;
public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable(nameof(Budget));

        builder.HasKey(budget => budget.Id);

        builder.OwnsMany(
          budget => budget.Categories,
          categoryNavigationBuilder =>
          {
              categoryNavigationBuilder.ToTable(nameof(Category));

              categoryNavigationBuilder.Property<int>("Id").IsRequired();
              categoryNavigationBuilder.HasKey("Id");



                categoryNavigationBuilder.OwnsMany(
                account => account.Transactions,
                transactionNavigationBuilder =>
                {
                    transactionNavigationBuilder.ToTable(nameof(Transaction));

                    transactionNavigationBuilder.Property<int>("Id").IsRequired();
                    transactionNavigationBuilder.HasKey("Id");
                }
            );
          }
        );
    }
}
