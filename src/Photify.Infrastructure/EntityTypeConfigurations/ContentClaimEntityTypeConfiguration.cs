using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photify.Domain.Entities;

namespace Photify.Infrastructure.EntityTypeConfigurations;

public class ContentClaimEntityTypeConfiguration : IEntityTypeConfiguration<ContentClaim>
{
    public void Configure(EntityTypeBuilder<ContentClaim> builder)
    {
        builder.ToTable("content_claim", PhotifyContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.Property(o => o.Id).HasColumnName("id");
        builder.Property(x => x.ContentId).HasColumnName("content_id");
        builder.Property(x => x.ClaimType).HasMaxLength(32).HasColumnName("claim_type");
        builder.Property(x => x.ClaimValue).HasMaxLength(512).HasColumnName("claim_value");
    }
}
