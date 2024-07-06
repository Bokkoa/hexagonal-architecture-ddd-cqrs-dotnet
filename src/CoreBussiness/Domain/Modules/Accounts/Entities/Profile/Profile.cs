using Domain.Abstractions.Entities;
using Domain.Modules.Accounts.Aggregates;

namespace Domain.Modules.Accounts.Entities.Profile;
public class Profile : Entity
{
    public Profile(string firstName, string lastName, string email)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    #region Navigation reference
    protected Profile() { }

    public Guid AccountId { get;  }
    public Account Account { get;  }

    #endregion
}
