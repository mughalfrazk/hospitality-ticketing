namespace Domain.Entities
{
    public class Gender : SoftDeletableEntity
    {
        public string Name { get; set; }
        
        public string? Description { get; set; }
    }
}

