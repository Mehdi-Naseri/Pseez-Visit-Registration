using System.Data.Entity.Migrations;
using Pseez.VisitRegistration.DataAccessLayer.DataContext;


namespace Pseez.VisitRegistration.DataAccessLayer.Migrations
{
    public class Configuration : DbMigrationsConfiguration<VisitRegistrationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(VisitRegistrationDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            SeedIdentity seedIdentity = new SeedIdentity();
            seedIdentity.CreateAdminUserAndRole();
            seedIdentity.AddRoles();

            seedIdentity.AddUsersandRoles();
        }
    }
}
