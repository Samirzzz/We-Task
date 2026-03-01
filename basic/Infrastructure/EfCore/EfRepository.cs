using basic.Infrastructure.Data;
using basic.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace basic.Infrastructure.EfCore
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext Context;

        public EfRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
    }
}