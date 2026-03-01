using basic.Domain.Interfaces;
using basic.Infrastructure.Data;
using basic.Domain.Models;
namespace basic.Infrastructure.EfCore{
    public class EfUserPermissionRepository : IUserPermissionRepository{
        private readonly AppDbContext _context;
        public EfUserPermissionRepository(AppDbContext context){
            _context = context;
        }
        public List<userPermission> getUserPermissions( string controller, string action){
            return  _context.Userpermissions.Where(p => p.controller == controller && p.action == action).ToList();
        
        }
    }
}