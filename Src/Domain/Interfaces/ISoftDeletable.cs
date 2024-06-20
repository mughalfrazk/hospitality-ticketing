namespace Domain.Interfaces
{
    public interface ISoftDeletable
    {

        DateTime? DeletedOn { get; }

        void Delete();

        void Restore();

    }
}
