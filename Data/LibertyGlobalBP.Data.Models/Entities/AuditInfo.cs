namespace LibertyGlobalBP.Data.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// We need to inherit this class in our database models if we want to keep track when the record has been created and modified.
    /// <summary>
    public abstract class AuditInfo : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Specifies whether or not the CreatedOn property should be automatically set.
        /// </summary>
        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
