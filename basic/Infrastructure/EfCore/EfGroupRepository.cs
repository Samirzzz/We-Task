using basic.Domain.Interfaces;
using basic.Infrastructure.Data;
using basic.Domain.Models;
namespace basic.Infrastructure.EfCore{
    public class EfGroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;
        public EfGroupRepository(AppDbContext context)
        {
            _context = context;
        }
        public Groups GetById(int id)
        {
            return _context.Groups.Find(id);
        }
        public List<Groups> getGroupsByIds(List<int> ids)
        {
            return _context.Groups.Where(g=>ids.Contains(g.id)).ToList();
        }
    }
}