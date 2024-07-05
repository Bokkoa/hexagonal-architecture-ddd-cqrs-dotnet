namespace Domain.Abstractions.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; protected set; }
        public bool IsDeleted { get; protected set; } 
    }
}
