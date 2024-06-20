namespace Domain.Interfaces
{
    public interface IEntity : IAuditable
    {
        /// <summary>
        /// Entity unique identifier.
        /// </summary>
        int Id { get; }
    }
}
