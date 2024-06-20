namespace Domain.Interfaces
{
    public interface IAuditable
    {
        /// <summary>
        /// User that created the record.
        /// </summary>
        string CreatedBy { get; }

        /// <summary>
        /// Creation date and time.
        /// </summary>
        DateTime? CreatedOn { get; }

        /// <summary>
        /// User that updated the record.
        /// </summary>
        string ModifiedBy { get; }

        /// <summary>
        /// Updated date and time.
        /// </summary>
        DateTime? ModifiedOn { get; }

        void SetModifiedBy(bool isInsert, string email);
    }
}
