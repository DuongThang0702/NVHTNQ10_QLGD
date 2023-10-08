using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    public class QLGDContext : IdentityDbContext<ApplicationUser>
    {
        public QLGDContext(DbContextOptions<QLGDContext> options)
            : base(options) { }
    }
}
