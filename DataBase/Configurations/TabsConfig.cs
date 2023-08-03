using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// TabsConfig
    /// </summary>
    public class TabsConfig : BaseEntityConfig<Tabs>
    {
        public override void Configure(EntityTypeBuilder<Tabs> builder)
        {
            builder.ToTable("Tabs");

            builder.Property(n => n.type)
                .HasMaxLength(4);

            builder.Property(n => n.text)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(n => n.key)
                .HasMaxLength(4);

            builder.Property(n => n.code)
                .IsUnicode()
                .HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
