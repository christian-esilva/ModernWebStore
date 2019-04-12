namespace ModernWebStore.Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ModernWebStore.Infra.Persistence.DataContext.StoreDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ModernWebStore.Infra.Persistence.DataContext.StoreDataContext";
        }

        protected override void Seed(ModernWebStore.Infra.Persistence.DataContext.StoreDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
