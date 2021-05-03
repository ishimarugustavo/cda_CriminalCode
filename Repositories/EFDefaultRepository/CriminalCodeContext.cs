using Microsoft.EntityFrameworkCore;
using CriminalCode.API.Models;

namespace CriminalCode.API.Repositories {
    public class CriminalCodeContext : DbContext {
        public CriminalCodeContext(DbContextOptions<CriminalCodeContext> options) : base (options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<CriminalCodes> CriminalCodes { get; set; }
    }
}
