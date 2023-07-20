using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// StoresConfig
    /// </summary>
    public class StoresConfig : BaseEntityConfig<Stores>
    {
        public override void Configure(EntityTypeBuilder<Stores> builder)
        {
            builder.ToTable("Stores");

            builder.Property(n => n.index)
                .HasMaxLength(4);

            builder.Property(n => n.name)
                .HasMaxLength(120);

            base.Configure(builder);
        }
    }
}
