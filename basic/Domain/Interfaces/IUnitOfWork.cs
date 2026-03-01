using basic.Infrastructure.Data;

namespace basic.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        AppDbContext Context { get; }

        int SaveChanges();
    }
}
