using basic.Domain.Models;
    namespace basic.Domain.Interfaces{
    public interface IUserPermissionRepository{
        List<userPermission> getUserPermissions(string controller, string action);
    }
}