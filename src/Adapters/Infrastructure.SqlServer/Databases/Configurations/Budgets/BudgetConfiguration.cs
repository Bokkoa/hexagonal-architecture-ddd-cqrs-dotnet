using Domain.Modules.Budgets.Aggregates;
using Domain.Modules.Budgets.ValueObjects.Categories;
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
          }
      );
    }
}
