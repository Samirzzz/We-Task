using basic.Infrastructure.Data;
using basic.Domain.Interfaces;

namespace basic.Infrastructure.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext Context { get; }

        public UnitOfWork(AppDbContext context)
        {
            Context = context;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
