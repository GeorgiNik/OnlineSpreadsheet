namespace OnlineSpreadsheet.Data.Models
{
    using System;
    using OnlineSpreadsheet.Data.Models.Entities;

    public class File : AuditInfo, IDeletableEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool CanBeDownloaded { get; set; }

        public DateTime? DeleteDate { get; set; }

        public string Size { get; set; }

        public string Description { get; set; }

        public int FolderID { get; set; }

        public virtual Folder Folder { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
