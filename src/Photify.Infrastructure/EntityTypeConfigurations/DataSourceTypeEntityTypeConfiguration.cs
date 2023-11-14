using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photify.Domain.Entities;

namespace Photify.Infrastructure.EntityTypeConfigurations;

public class DataSourceTypeEntityTypeConfiguration : IEntityTypeConfiguration<DataSourceType>
{
    public void Configure(EntityTypeBuilder<DataSourceType> builder)
    {
        builder.ToTable("data_source_type", PhotifyContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.Property(o => o.Id).HasColumnName("id").HasDefaultValue(1).ValueGeneratedNever().IsRequired();
        builder.Property(x => x.Name).HasMaxLength(64).HasColumnName("name").IsRequired();

    }
}
