using DataBase.Configurations;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public partial class SkusContext : DataBaseContext
    {
        public SkusContext()
        {
        }
        public DbSet<Skus> Skus { get; set; } = null!;
        public SkusContext(DbContextOptions<SkusContext> options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var config = new SkusConfig();
            modelBuilder.ApplyConfiguration(config);

            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            modelBuilder.Entity<Skus>().ToTable("Skus");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
