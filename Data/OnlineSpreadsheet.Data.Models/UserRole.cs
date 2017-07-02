namespace OnlineSpreadsheet.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using OnlineSpreadsheet.Data.Models.Entities;

    public class UserRole : DeletableEntity, IEntity
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public bool ConfigurationRead { get; set; }

        public bool ConfigurationEdit { get; set; }

        public bool ProjectFilesRead { get; set; }

        public bool ProjectFilesEdit { get; set; }

        public bool UserRolesRead { get; set; }

        public bool UserRolesEdit { get; set; }

        public bool UsersRead { get; set; }

        public bool UsersEdit { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
