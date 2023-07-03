using Microsoft.EntityFrameworkCore;
using Models;

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
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            modelBuilder.Entity<Log>().ToTable("Log");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
