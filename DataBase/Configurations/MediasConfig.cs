using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// MediasConfig
    /// </summary>
    public class MediasConfig : BaseEntityConfig<Medias>
    {
        public override void Configure(EntityTypeBuilder<Medias> builder)
        {
            builder.ToTable("Medias");

            builder.Property(n => n.tableType)
                .HasMaxLength(4);

            builder.Property(n => n.mType)
                .HasMaxLength(4);

            builder.Property(n => n.tableId)
                .HasMaxLength(20);

            builder.Property(n => n.path)
                .IsUnicode()
                .HasMaxLength(250);

            //builder.Property(n => n.content);

            builder.Property(n => n.flag)
                .IsUnicode()
                .HasMaxLength(20);

            base.Configure(builder);
        }
    }
}
