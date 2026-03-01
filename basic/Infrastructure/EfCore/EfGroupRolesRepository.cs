using basic.Domain.Interfaces;
using basic.Infrastructure.Data;
using basic.Domain.Models;
namespace basic.Infrastructure.EfCore{
    public class EfGroupRolesRepository : IGroupRolesRepository{
        private readonly AppDbContext _context;
        public EfGroupRolesRepository(AppDbContext context){
            _context = context;
        }
        public Grouproles getGroupId(int id){
            return _context.Grouproles.Find(id);
        }
        public Grouproles getRoleId(int id){
            return _context.Grouproles.Find(id);
        }
        public bool hasAccess(List<int> groupIds, List<int> roleIds){
            return _context.Grouproles.Any(x=>groupIds.Contains(x.groupId) && roleIds.Contains(x.roleId));
        }
        public List<Grouproles> getGroupRoles(List<int> groupIds){
            return _context.Grouproles.Where(x=>groupIds.Contains(x.groupId)).ToList();
        }
    }
}