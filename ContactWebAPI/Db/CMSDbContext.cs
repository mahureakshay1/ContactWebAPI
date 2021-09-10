using Microsoft.EntityFrameworkCore;

namespace ContactWebAPI.Db
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext(DbContextOptions<CMSDbContext> cMSDbContextOpt)
            : base(cMSDbContextOpt)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
