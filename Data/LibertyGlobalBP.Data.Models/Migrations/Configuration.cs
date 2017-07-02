namespace LibertyGlobalBP.Data.Models.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EfEnumToLookup.LookupGenerator;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var enumToLookup = new EnumToLookup();
            enumToLookup.TableNamePrefix = null;
            enumToLookup.Apply(context);

            this.SeedRoles(context);
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            var admin = new UserRole
            {
                Name = "Administrator",
                CreatedOn = DateTime.UtcNow
            };

            var globalReader = new UserRole()
            {
                Name = "Global Reader",
                CreatedOn = DateTime.UtcNow,
                ProjectFilesRead = true,
                ProjectFilesEdit = true,
            };

            foreach (var field in admin.GetType().GetProperties().Where(x => x.PropertyType == false.GetType()))
            {
                field.SetValue(admin, true, null);
            }

            admin.IsDeleted = false;

            var roles = new List<UserRole> { admin, globalReader };

            roles.ForEach(entry => context.UserRoles.AddOrUpdate(x => x.Name, entry));
            context.SaveChanges();
        }
    }
}
