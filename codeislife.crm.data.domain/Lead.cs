﻿using codeislife.crm.core.Abstraction;

namespace codeislife.crm.data.domain;
public class Lead : BaseEntity<Guid>, IHasCreatedDate
{
    public string Description { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Comment { get; set; }

    // TODO : Burası EF Core içinde nasıl davranıyor göster!
    public LeadState State { get; set; } = LeadState.New;

    // TODO : Default Value nasıl atanır göster
    public DateTime CreatedDateUtc { get; set; }
    public Guid? CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual ICollection<DashboardStageLead> StageLeads { get; set; }
}
