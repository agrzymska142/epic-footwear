using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Grzymska.EpicFootwear.DAOSQL
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext() { }

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = GetDatabasePath();

            optionsBuilder.UseSqlite($"Data source={databasePath}");
        }

        private string GetDatabasePath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            string relativePathToDatabase = "DAOSQL\\catalog.db";

            return Path.Combine(projectDirectory, relativePathToDatabase);
        }


        public DbSet<Brand> Brands { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
    }
}
