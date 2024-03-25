using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codeislife.crm.data.domain.Builders;
public class DashboardBuilder : IEntityTypeConfiguration<Dashboard>
{
    public void Configure(EntityTypeBuilder<Dashboard> builder)
    {
        builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
    }
}
