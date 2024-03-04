using codeislife.crm.core.Abstraction;

namespace codeislife.crm.data.domain;
public class Customer : BaseEntity<Guid>, ISoftDeletable, IHasCreatedDate
{
    // ünvan
    public string Title { get; set; }

    public string Code { get; set; }

    public bool Deleted { get; set; }

    public DateTime CreatedDateUtc { get; set; }

    public virtual ICollection<Lead> Leads { get; set; } = [];
    public virtual ICollection<CustomerContact> CustomerContacts { get; set; } = [];
}
