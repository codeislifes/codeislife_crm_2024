using codeislife.crm.core.Abstraction;

namespace codeislife.crm.data.domain;
public class Contact : BaseEntity<Guid>, ISoftDeletable, IHasCreatedDate
{
    public string Firsname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedDateUtc { get; set; }
    public virtual ICollection<CustomerContact> CustomerContacts { get; set; } = [];
}
