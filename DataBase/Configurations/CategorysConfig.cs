using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// CategorysConfig
    /// </summary>
    public class CategorysConfig : BaseEntityConfig<Categorys>
    {
        public override void Configure(EntityTypeBuilder<Categorys> builder)
        {
            builder.ToTable("Categorys");

            builder.Property(n => n.parentId)
                .HasMaxLength(20);

            builder.Property(n => n.name)
                .IsUnicode()
                .HasMaxLength(20);

            builder.Property(n => n.thumbnailPath)
                .IsUnicode()
                .HasMaxLength(200);

            //builder.Property(n => n.thumbnailContent);

            //builder.Property(n => n.cancelTime);

            base.Configure(builder);
        }
    }
}
