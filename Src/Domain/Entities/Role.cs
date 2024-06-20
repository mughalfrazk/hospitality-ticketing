namespace Domain.Entities
{
    public class Role : SoftDeletableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
