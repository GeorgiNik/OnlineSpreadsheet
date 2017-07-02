namespace LibertyGlobalBP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using LibertyGlobalBP.Data.Models.Entities;

    public class Folder : AuditInfo, IDeletableEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? ParentFolderID { get; set; }

        public virtual Folder ParentFolder { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public virtual ICollection<Folder> Folders { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}