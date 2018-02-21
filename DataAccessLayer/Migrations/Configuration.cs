namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DataAccessLayer.BlogDbContext";
        }

        protected override void Seed(DataAccessLayer.BlogDbContext context)
        {
            if (!context.Posts.Any())
            {
                BlogDbInitializer.InitializeData(context);
            }
        }
    }
}
