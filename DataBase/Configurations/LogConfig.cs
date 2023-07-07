using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// LogConfig
    /// </summary>
    public class LogConfig : BaseEntityConfig<Log>
    {
        public override void Configure(EntityTypeBuilder<Log> builder)
        {
            //builder.HasComment("日志表");
            builder.ToTable("Log");

            builder.Property(n => n.subject)
                .IsUnicode()
                .HasMaxLength(100);

            builder.Property(n => n.message)
                .IsUnicode()
                .HasMaxLength(2000);

            builder.Property(n => n.creator)
                .IsUnicode()
                .HasMaxLength(15);

            base.Configure(builder);
        }
    }
}
