using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// SpecsConfig
    /// </summary>
    public class SpecsConfig : BaseEntityConfig<Specs>
    {
        public override void Configure(EntityTypeBuilder<Specs> builder)
        {
            builder.ToTable("Specs");

            builder.Property(n => n.goodsId)
                .HasMaxLength(20);

            builder.Property(n => n.index)
                .HasMaxLength(4);

            builder.Property(n => n.title)
                .IsUnicode()
                .HasMaxLength(50);

            base.Configure(builder);
        }
    }
}
