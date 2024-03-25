using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codeislife.crm.data.domain.Builders;
public class DashboardStageBuilder : IEntityTypeConfiguration<DashboardStage>
{
    public void Configure(EntityTypeBuilder<DashboardStage> builder)
    {
        builder.HasOne(dbs => dbs.Dashboard)
            .WithMany(db => db.Stages)
            .HasForeignKey(p => p.DashboardId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Property(p => p.DisplayOrder).IsRequired();

        //builder.Property(p => p.OnLeadState)
        //    .HasConversion<int>()
        //    .HasField("LeadState");
       // builder.Ignore(p => p.OnLeadState);
    }
}
