using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    /// <summary>
    /// SpecValsConfig
    /// </summary>
    public class SpecValsConfig : BaseEntityConfig<SpecVals>
    {
        public override void Configure(EntityTypeBuilder<SpecVals> builder)
        {
            builder.ToTable("SpecVals");

            builder.Property(n => n.specId)
                .HasMaxLength(20);

            builder.Property(n => n.saasId)
                .IsUnicode()
                .HasMaxLength(25);

            builder.Property(n => n.index)
                .HasMaxLength(4);

            builder.Property(n => n.value)
                .IsUnicode()
                .HasMaxLength(25);

            base.Configure(builder);
        }
    }
}
