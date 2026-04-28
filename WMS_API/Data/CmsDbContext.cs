using Microsoft.EntityFrameworkCore;
using WMS_API.Models;

namespace WMS_API.Data
{
    public class CmsDbContext : DbContext
    {
        public CmsDbContext(DbContextOptions<CmsDbContext> options) : base(options)
        {
        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Party> Party { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Sys_Users> Sys_Users { get; set; }
        public DbSet<STP_Roles> STP_Roles { get; set; }
    }
}
