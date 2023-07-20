using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// CommentsConfig
    /// </summary>
    public class CommentsConfig : BaseEntityConfig<Comments>
    {
        public override void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.ToTable("Comments");

            builder.Property(n => n.goodsId)
                .HasMaxLength(20);

            builder.Property(n => n.skuId)
                .HasMaxLength(20);

            builder.Property(n => n.spuId)
                .IsUnicode()
                .HasMaxLength(25);

            builder.Property(n => n.content)
                .IsUnicode()
                .HasMaxLength(4000);

            builder.Property(n => n.uCode)
                .IsUnicode()
                .HasMaxLength(25);

            builder.Property(n => n.uName)
                .IsUnicode()
                .HasMaxLength(50);

            //builder.Property(n => n.isAnonymity);

            //builder.Property(n => n.commentTime);

            //builder.Property(n => n.isAutoComment);

            builder.Property(n => n.sellerReply)
                .IsUnicode()
                .HasMaxLength(4000);

            builder.Property(n => n.goodsDetailInfo)
                .IsUnicode()
                .HasMaxLength(200);

            //builder.Property(n => n.cancelTime);

            base.Configure(builder);
        }
    }
}
