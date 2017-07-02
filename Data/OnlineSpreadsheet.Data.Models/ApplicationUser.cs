namespace OnlineSpreadsheet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using OnlineSpreadsheet.Data.Models.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser, IDeletableEntity, IAuditInfo
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Phone { get; set; }

        public string PasswordResetToken { get; set; }

        public EntityStatus EntityStatus { get; set; }

        public int? UserRoleID { get; set; }

        public virtual UserRole UserRole { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

        public bool HasAccess(AccessRequest? area)
        {
            if (this.UserRole == null)
            {
                return false;
            }

            switch (area)
            {
                case AccessRequest.ConfigurationRead:
                    return this.UserRole.ConfigurationRead;
                case AccessRequest.ConfigurationEdit:
                    return this.UserRole.ConfigurationEdit;
                case AccessRequest.ProjectFilesRead:
                    return this.UserRole.ProjectFilesRead;
                case AccessRequest.ProjectFilesEdit:
                    return this.UserRole.ProjectFilesEdit;
                case AccessRequest.UserRolesRead:
                    return this.UserRole.UserRolesRead;
                case AccessRequest.UserRolesEdit:
                    return this.UserRole.UserRolesEdit;
                case AccessRequest.UsersRead:
                    return this.UserRole.UsersRead;
                case AccessRequest.UsersEdit:
                    return this.UserRole.UsersEdit;
                default:
                    return false;
            }
        }
    }
}
