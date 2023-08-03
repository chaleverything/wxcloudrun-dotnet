using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public partial class DataBaseContext: DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var username = Environment.GetEnvironmentVariable("MYSQL_USERNAME");
                var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
                var addressParts = Environment.GetEnvironmentVariable("MYSQL_ADDRESS")?.Split(':');
                var host = addressParts?[0];
                var port = addressParts?[1];
                var database = "aspnet_demo";

                var connstr = $"server={host};port={port};user={username};password={password};database={database}";
                optionsBuilder.UseMySql(connstr, Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UseCollation("utf8_general_ci")
            //    .HasCharSet("utf8");
            modelBuilder.UseCollation("utf8mb4_general_ci")
               .HasCharSet("utf8mb4");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}