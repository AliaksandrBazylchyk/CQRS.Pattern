using CQRS.Pattern.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Pattern.DAL.Contexts
{
    public class NpgsqlContext : DbContext
    {
        public DbSet<Person> Users { get; set; }

        public NpgsqlContext()
        {
        }

        public NpgsqlContext(DbContextOptions options) : base(options)
        {
        }
    }
}