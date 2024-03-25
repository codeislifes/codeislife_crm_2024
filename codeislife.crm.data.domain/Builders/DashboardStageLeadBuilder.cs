using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codeislife.crm.data.domain.Builders;
public class DashboardStageLeadBuilder : IEntityTypeConfiguration<DashboardStageLead>
{
    public void Configure(EntityTypeBuilder<DashboardStageLead> builder)
    {
        builder.HasOne(dbsl=> dbsl.Lead)
            .WithMany(dbs=> dbs.StageLeads)
            .HasForeignKey(p => p.LeadId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.DisplayOrder).IsRequired();
    }
}
