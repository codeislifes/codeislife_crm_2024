namespace codeislife.crm.data.domain;

public partial class DashboardStage : BaseEntity<Guid>
{
    public Guid DashboardId { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public LeadState OnLeadState { get; set; }
    public virtual Dashboard Dashboard { get; set; }
}
