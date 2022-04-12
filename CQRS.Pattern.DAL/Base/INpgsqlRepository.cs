namespace CQRS.Pattern.DAL.Base
{
    public interface INpgsqlRepository<T> : IRepository<T>
        where T : BaseEntity
    {
    }
}