using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// KeywordHistorysConfig
    /// </summary>
    public class KeywordHistorysConfig : BaseEntityConfig<KeywordHistorys>
    {
        public override void Configure(EntityTypeBuilder<KeywordHistorys> builder)
        {
            builder.ToTable("KeywordHistorys");

            builder.Property(n => n.openId)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(n => n.unionId)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(n => n.content)
                .IsUnicode()
                .HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
