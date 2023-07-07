using DataBase.Configurations;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public partial class LogContext : DataBaseContext
    {
        public LogContext()
        {
        }
        public DbSet<Log> Log { get; set; } = null!;
        public LogContext(DbContextOptions<LogContext> options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LogConfig logConfig = new LogConfig();
            modelBuilder.ApplyConfiguration(logConfig);

            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            modelBuilder.Entity<Log>().ToTable("Log");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
