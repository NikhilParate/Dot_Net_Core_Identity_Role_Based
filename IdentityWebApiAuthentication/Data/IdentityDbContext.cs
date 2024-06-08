using IdentityWebApiAuthentication.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace IdentityWebApiAuthentication.Data
{
    public class IdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> dbContextOptions)
            : base (dbContextOptions)
        {
            

        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
