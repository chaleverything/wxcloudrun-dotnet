using DataBase.Configurations;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public partial class SpecValsContext : DataBaseContext
    {
        public SpecValsContext()
        {
        }
        public DbSet<SpecVals> SpecVals { get; set; } = null!;
        public SpecValsContext(DbContextOptions<SpecValsContext> options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var config = new SpecValsConfig();
            modelBuilder.ApplyConfiguration(config);

            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            modelBuilder.Entity<SpecVals>().ToTable("SpecVals");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
