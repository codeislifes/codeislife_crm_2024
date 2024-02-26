using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace codeislife.crm.identity;
public class CrmIdentityDbContext : IdentityDbContext
{
    public CrmIdentityDbContext(DbContextOptions options) : base(options)
    {
    }
}
