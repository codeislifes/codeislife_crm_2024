namespace codeislife.crm.data.domain;
public class CustomerContact : BaseEntity<Guid>
{
    public Guid ContactId { get; set; }
    public Guid CustomerId { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Contact Contact { get; set; }
}
