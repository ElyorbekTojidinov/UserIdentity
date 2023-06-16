using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserIdentity.Models;

namespace UserIdentity.Data
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) 
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
