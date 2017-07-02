namespace OnlineSpreadsheet.Data.Models.Entities
{
    using System;

    public class DeletableEntity : AuditInfo, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
