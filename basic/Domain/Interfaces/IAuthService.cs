using basic.Domain.Models;
using basic.Application.shared;
using basic.Application.DTOs;
namespace basic.Domain.Interfaces{
public interface IAuthService{
    Response<User> Register(User user);
    bool emailExists(string email);
    Response<Groups> AddGroup(Groups group);
    Response<Usergroups> AddUserToGroup(int userId, int groupId);
    Response<Grouproles> AddRoleToGroup(int groupId, int roleId);
    Response<roles> AddRole(roles role);
    Response<List<string>> getusergroups(int userId);
    Response<string> Login(string email, string password);
    string generateToken(User user);
    Response<List<UserGroupRoleDto>> getUserGroupRole(int userId);

}
}