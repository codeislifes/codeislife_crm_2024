namespace codeislife.crm.data.domain;

public partial class DashboardStageLead : BaseEntity<Guid>
{
    public Guid DashboardStageId { get; set; }
    public Guid LeadId { get; set; }
    public int DisplayOrder { get; set; }
    public virtual Lead Lead { get; set; }
}