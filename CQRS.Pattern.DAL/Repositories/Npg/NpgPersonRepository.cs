using CQRS.Pattern.DAL.Base;
using CQRS.Pattern.DAL.Contexts;
using CQRS.Pattern.DAL.Entities;

namespace CQRS.Pattern.DAL.Repositories.Npg
{
    public class NpgPersonRepository : NpgsqlRepository<Person>, INpgPersonRepository
    {
        public NpgPersonRepository(NpgsqlContext context) : base(context)
        {
        }
    }
}