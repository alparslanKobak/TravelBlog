using System.Data.Entity;

namespace TravelBlog.Entity.DbSeeder
{
    public class MyDbInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            // Burada veritabanı seed işlemleri yapılır.
            DbSeeder.DbSeed();
        }
    }
}