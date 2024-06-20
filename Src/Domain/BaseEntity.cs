using Domain.Interfaces;

namespace Domain
{
    public class BaseEntity : IEntity
    {
        public int Id { get; private set; }

        public string CreatedBy { get; private set; } = "N/A";

        public DateTime? CreatedOn { get; private set; } = DateTime.UtcNow;

        public string ModifiedBy { get; private set; } = "N/A";

        public DateTime? ModifiedOn { get; private set; } = DateTime.Now;

        public void SetModifiedBy(bool isInsert, string email)
        {
            var now = DateTime.UtcNow;
            if (isInsert)
            {
                this.CreatedBy = email;
                this.CreatedOn = now;
            }
            
            this.ModifiedBy = email;
            this.ModifiedOn = now;
        }
    }
}
