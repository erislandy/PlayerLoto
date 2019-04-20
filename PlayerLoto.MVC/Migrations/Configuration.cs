namespace PlayerLoto.MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PlayerLoto.MVC.Models.PlayerLotoContextMVC>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PlayerLoto.MVC.Models.PlayerLotoContextMVC";
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(PlayerLoto.MVC.Models.PlayerLotoContextMVC context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
