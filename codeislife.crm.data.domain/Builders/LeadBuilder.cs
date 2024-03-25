using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codeislife.crm.data.domain.Builders;
public class LeadBuilder : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.HasOne(l => l.Customer)
            .WithMany(c => c.Leads)
            .HasForeignKey(p => p.CustomerId)
            .IsRequired(false);

        builder
             .Property(p => p.Comment)
             .HasMaxLength(500)
             .IsRequired(false);
    }
}
