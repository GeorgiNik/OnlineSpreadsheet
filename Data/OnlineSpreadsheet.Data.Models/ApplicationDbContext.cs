namespace OnlineSpreadsheet.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using OnlineSpreadsheet.Data.Models.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
                : base("DefaultConnection", false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ApplicationDbContext, OnlineSpreadsheet.Data.Models.Migrations.Configuration>()
            );
        }
        
        public IDbSet<EmailFailureLog> EmailFailureLogs { get; set; }

        public IDbSet<EmailSuccessLog> EmailSuccessLogs { get; set; }

        public IDbSet<File> Files { get; set; }

        public IDbSet<Folder> Folders { get; set; }

        public IDbSet<NLogEntry> NLogEntries { get; set; }

        public IDbSet<UserRole> UserRoles { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in this.ChangeTracker.Entries()
                    .Where(e => e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}