using CQRS.Pattern.Models.Persons;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Pattern.Infrastructure.Contexts
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