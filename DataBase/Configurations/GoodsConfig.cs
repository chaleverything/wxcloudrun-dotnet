using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// GoodsConfig
    /// </summary>
    public class GoodsConfig : BaseEntityConfig<Goods>
    {
        public override void Configure(EntityTypeBuilder<Goods> builder)
        {
            builder.ToTable("Goods");

            builder.Property(n => n.saasId)
                .IsUnicode()
                .HasMaxLength(25);

            builder.Property(n => n.storeId)
                .HasMaxLength(20);

            builder.Property(n => n.spuId)
                .IsUnicode()
                .HasMaxLength(25);

            builder.Property(n => n.hitQuantity)
                .HasMaxLength(20);

            builder.Property(n => n.title)
                .IsUnicode()
                .HasMaxLength(250);

            builder.Property(n => n.etitle)
                .IsUnicode()
                .HasMaxLength(250);

            builder.Property(n => n.tag)
                .IsUnicode()
                .HasMaxLength(100);

            builder.Property(n => n.categoryIds)
                .IsUnicode()
                .HasMaxLength(200);

            //builder.Property(n => n.available);

            builder.Property(n => n.minSalePrice)
                .HasMaxLength(11);

            builder.Property(n => n.minLinePrice)
                .HasMaxLength(11);

            builder.Property(n => n.maxSalePrice)
                .HasMaxLength(11);

            builder.Property(n => n.maxLinePrice)
                .HasMaxLength(11);

            builder.Property(n => n.stockQuantity)
                .HasMaxLength(11);

            builder.Property(n => n.soldNum)
                .HasMaxLength(11);

            //builder.Property(n => n.isPutOnSale);

            builder.Property(n => n.spuTagList)
                .IsUnicode()
                .HasMaxLength(500);

            builder.Property(n => n.limitInfo)
                .IsUnicode()
                .HasMaxLength(300);

            //builder.Property(n => n.updateTime);

            builder.Property(n => n.updateBy)
                .IsUnicode()
                .HasMaxLength(15);

            //builder.Property(n => n.cancelTime);

            base.Configure(builder);
        }
    }
}
