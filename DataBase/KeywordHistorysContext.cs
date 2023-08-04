using DataBase.Configurations;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public partial class KeywordHistorysContext : DataBaseContext
    {
        public KeywordHistorysContext()
        {
        }
        public DbSet<KeywordHistorys> KeywordHistorys { get; set; } = null!;
        public KeywordHistorysContext(DbContextOptions<KeywordHistorysContext> options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var config = new KeywordHistorysConfig();
            modelBuilder.ApplyConfiguration(config);

            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            modelBuilder.Entity<KeywordHistorys>().ToTable("KeywordHistorys");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
