using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    public abstract class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(n => n.id);

            builder.Property(n => n.id)
                   .ValueGeneratedOnAdd()
                   .HasComment("系统设置表唯一识别ID");

            builder.Property(n => n.creationTime)
                   .IsRequired()
                   .HasComment("创建时间")
                   .ValueGeneratedOnAdd();
        }
    }
}
