using basic.Domain.Models;
namespace basic.Domain.Interfaces{
    public interface IGroupRolesRepository{
        Grouproles getGroupId(int id);
        Grouproles getRoleId(int id);
        bool hasAccess(List<int> groupIds, List<int> roleIds);
        List<Grouproles> getGroupRoles(List<int> groupIds);
    }
}