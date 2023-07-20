using DataBase.Configurations;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public partial class MediasContext : DataBaseContext
    {
        public MediasContext()
        {
        }
        public DbSet<Medias> Medias { get; set; } = null!;
        public MediasContext(DbContextOptions<MediasContext> options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var config = new MediasConfig();
            modelBuilder.ApplyConfiguration(config);

            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            modelBuilder.Entity<Medias>().ToTable("Medias");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
