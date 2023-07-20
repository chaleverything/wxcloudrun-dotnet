using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// SkusConfig
    /// </summary>
    public class SkusConfig : BaseEntityConfig<Skus>
    {
        public override void Configure(EntityTypeBuilder<Skus> builder)
        {
            builder.ToTable("Skus");

            builder.Property(n => n.goodsId)
                .HasMaxLength(20);

            builder.Property(n => n.index)
                .HasMaxLength(4);

            builder.Property(n => n.specInfo)
                .IsUnicode()
                .HasMaxLength(2000);

            builder.Property(n => n.priceInfo)
                .IsUnicode()
                .HasMaxLength(2000);

            builder.Property(n => n.stockInfo)
                .IsUnicode()
                .HasMaxLength(2000);

            builder.Property(n => n.weight)
                .IsUnicode()
                .HasMaxLength(120);

            builder.Property(n => n.volume)
                .IsUnicode()
                .HasMaxLength(120);

            builder.Property(n => n.profitPrice)
                .IsUnicode()
                .HasMaxLength(120);

            base.Configure(builder);
        }
    }
}
