using DataEncryption.Models;
using Microsoft.EntityFrameworkCore;

namespace DataEncryption.Data
{
    public class CryptographyContext: DbContext
    {
        public CryptographyContext(DbContextOptions<CryptographyContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
