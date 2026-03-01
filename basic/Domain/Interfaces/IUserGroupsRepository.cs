
using basic.Domain.Models;
 
namespace basic.Domain.Interfaces{
public interface IUserGroupsRepository{

Usergroups getGroupId(int id);
Usergroups getUserId(int id);
List<Usergroups> getUserGroups(int userId);



}


}