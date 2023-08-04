using DataBase.Configurations;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public partial class UserContext : DataBaseContext
    {
        public UserContext()
        {
        }
        public DbSet<User> User { get; set; } = null!;
        public UserContext(DbContextOptions<UserContext> options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var config = new UserConfig();
            modelBuilder.ApplyConfiguration(config);

            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            modelBuilder.Entity<User>().ToTable("User");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
