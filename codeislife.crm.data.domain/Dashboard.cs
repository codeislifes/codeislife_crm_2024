namespace codeislife.crm.data.domain;
public partial class Dashboard : BaseEntity<Guid>
{
    public string Title { get; set; }
    public Guid UserId { get; set; }

    public virtual ICollection<DashboardStage> Stages { get; set; }
}
