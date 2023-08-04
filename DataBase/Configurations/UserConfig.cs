using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// UserConfig
    /// </summary>
    public class UserConfig : BaseEntityConfig<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(n => n.openId)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(n => n.unionId)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(n => n.name)
                .IsUnicode()
                .HasMaxLength(120);

            builder.Property(n => n.nickName)
                .IsUnicode()
                .HasMaxLength(120);

            builder.Property(n => n.gender)
                .HasMaxLength(4);

            builder.Property(n => n.city)
                .IsUnicode()
                .HasMaxLength(30);

            builder.Property(n => n.province)
                .IsUnicode()
                .HasMaxLength(30);

            builder.Property(n => n.country)
                .IsUnicode()
                .HasMaxLength(30);

            builder.Property(n => n.status)
                .HasMaxLength(4);

            base.Configure(builder);
        }
    }
}
