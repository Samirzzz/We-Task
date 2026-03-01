using basic.Domain.Interfaces;
using basic.Infrastructure.Data;
using basic.Domain.Models;
namespace basic.Infrastructure.EfCore{
    public class EfUserGroupsRepository : IUserGroupsRepository{
        private readonly AppDbContext _context;

        public EfUserGroupsRepository(AppDbContext context){
            _context = context;
        }
        public Usergroups getGroupId(int id){
            return _context.Usergroups.Find(id);
        }
        public Usergroups getUserId(int id){
            return _context.Usergroups.Find(id);
        }
        public List<Usergroups> getUserGroups(int userId){
            return _context.Usergroups.Where(u=>u.userId==userId).ToList();
        }
        
        
    }
}