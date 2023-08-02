using DataBase.Configurations;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public partial class TabsContext : DataBaseContext
    {
        public TabsContext()
        {
        }
        public DbSet<Tabs> Tabs { get; set; } = null!;
        public TabsContext(DbContextOptions<TabsContext> options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var config = new TabsConfig();
            modelBuilder.ApplyConfiguration(config);

            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            modelBuilder.Entity<Tabs>().ToTable("Tabs");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
