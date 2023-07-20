using DataBase.Configurations;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public partial class CategorysContext : DataBaseContext
    {
        public CategorysContext()
        {
        }
        public DbSet<Categorys> Categorys { get; set; } = null!;
        public CategorysContext(DbContextOptions<CategorysContext> options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var config = new CategorysConfig();
            modelBuilder.ApplyConfiguration(config);

            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            modelBuilder.Entity<Categorys>().ToTable("Categorys");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
