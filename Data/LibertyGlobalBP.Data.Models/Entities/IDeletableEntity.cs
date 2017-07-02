namespace LibertyGlobalBP.Data.Models.Entities
{
    using System;

    /// <summary>
    /// Index the IsDeleted property in all models which implement this interface for faster queries.
    /// (Apply Index label on the property).
    /// <summary>
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
