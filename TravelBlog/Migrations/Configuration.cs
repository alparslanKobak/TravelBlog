namespace TravelBlog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TravelBlog.Entity.DbSeeder;

    internal sealed class Configuration : DbMigrationsConfiguration<TravelBlog.Entity.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TravelBlog.Entity.DataContext context)
        {

        }
    }
}
