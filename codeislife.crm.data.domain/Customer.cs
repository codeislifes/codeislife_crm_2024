using codeislife.crm.core.Abstraction;

namespace codeislife.crm.data.domain;
public class Customer : BaseEntity<Guid>, ISoftDeletable, IHasCreatedDate
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Deleted { get; set; }

    // TODO : Default Value nasıl atanır göster
    public DateTime CreatedDateUtc { get; set; }

    public ICollection<Lead> Leads { get; set; } = new List<Lead>();
}
