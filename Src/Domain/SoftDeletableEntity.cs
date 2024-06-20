using Domain.Interfaces;

namespace Domain
{
    public class SoftDeletableEntity : BaseEntity, ISoftDeletable
    {

        public DateTime? DeletedOn { get; private set; }

        public virtual void Delete()
        {
            this.DeletedOn = DateTime.UtcNow;
        }

        public virtual void Delete(DateTime deletedOn)
        {
            this.DeletedOn = deletedOn;
        }

        public void Restore()
        {
            this.DeletedOn = null;
        }
    }
}
