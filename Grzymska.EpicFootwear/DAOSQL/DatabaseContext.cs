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
            try
            {
                optionsBuilder.UseSqlite($"Data source={databasePath}");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + $"\nPath to database file: {databasePath}");
            }
        }

        private string GetDatabasePath()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectName = "Grzymska.EpicFootwear";

            int lastIndex = baseDirectory.LastIndexOf(projectName);

            if (lastIndex != -1)
            {
                string projectPath = baseDirectory.Substring(0, lastIndex + projectName.Length);

                string relativePathToDatabase = "DAOSQL\\catalog.db";
                return Path.Combine(projectPath, relativePathToDatabase);
            }
            else
            {
                throw new InvalidOperationException("Project name not found in the base directory path.");
            }
        }




        public DbSet<Brand> Brands { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
    }
}
