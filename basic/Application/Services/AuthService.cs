using basic.Domain.Models;
using basic.Domain.Interfaces;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using basic.Application.shared;

namespace basic.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _genericUserRepository;
        private readonly IRepository<Groups> _genericGroupsRepository;
        private readonly IRepository<Usergroups> _genericUserGroupsRepository;
        private readonly IRepository<Grouproles> _genericGroupRolesRepository;
        private readonly IRepository<roles> _genericRolesRepository;
        private readonly IGroupRolesRepository _groupRolesRepository;
        private readonly IUserGroupsRepository _userGroupsRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IConfiguration _configuration;
private readonly IUnitOfWork _unitOfWork;
        public AuthService(IRepository<User> genericUserRepository, IRepository<Groups> genericGroupsRepository, IUserRepository userRepository, IGroupRepository groupRepository, IUnitOfWork unitOfWork, IRepository<roles> genericRolesRepository, IGroupRolesRepository groupRolesRepository, IUserGroupsRepository userGroupsRepository, IRepository<Usergroups> genericUserGroupsRepository, IRepository<Grouproles> genericGroupRolesRepository, IConfiguration configuration)
        {
            _genericUserRepository = genericUserRepository;
            _genericGroupsRepository = genericGroupsRepository;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
            _genericRolesRepository = genericRolesRepository;
            _groupRolesRepository = groupRolesRepository;
            _userGroupsRepository = userGroupsRepository;
            _genericUserGroupsRepository = genericUserGroupsRepository;
            _genericGroupRolesRepository = genericGroupRolesRepository;
            _configuration = configuration;
        }

        public Response<User> Register(User user)
        {
            if (emailExists(user.email))
            {
                throw new Exception("Email already exists");
            }
           
           

            _genericUserRepository.Add(user);
            _unitOfWork.SaveChanges();
            return new Response<User>(message: "User registered successfullyyy", data: user);
        }
        public  Response<Usergroups> AddUserToGroup(int userId, int groupId){

          
           var userGroup = new Usergroups{
            userId = userId,
            groupId = groupId
           };
            _genericUserGroupsRepository.Add(userGroup);
            _unitOfWork.SaveChanges();
            return new Response<Usergroups>(message: "User added to group successfully", data: userGroup);
        }
 public Response<Grouproles> AddRoleToGroup(int groupId, int roleId){
   
    var groupRole = new Grouproles{
        groupId = groupId,
        roleId = roleId
    };
            _genericGroupRolesRepository.Add(groupRole);
            _unitOfWork.SaveChanges();
            return new Response<Grouproles>(message: "Role added to group successfully", data: groupRole);
        }
public Response<roles> AddRole(roles role)
{
    _genericRolesRepository.Add(role);
    _unitOfWork.SaveChanges();
    return new Response<roles>(message: "Role added successfully", data: role);
}
        public Response<Groups> AddGroup(Groups group)
        {
            _genericGroupsRepository.Add(group);
            _unitOfWork.SaveChanges();
            return new Response<Groups>(message: "Group added successfully", data: group);
        }
        public bool emailExists(string email)
        {
            return _userRepository.GetByEmail(email) != null;
        }

        public Response<List<string>> getusergroups(int userId){
            var userGroups=_userGroupsRepository.getUserGroups(userId);
            var groupIds=userGroups.Select(u=>u.groupId).ToList();
            var groups = _groupRepository.getGroupsByIds(groupIds);
            if (userGroups == null)
            {
                throw new Exception("User groups not found");
            }
            return new Response<List<string>>(message: "User groups found", data: groups.Select(g=>g.name).ToList());
        }

     public Response<string> Login(string email, string password){
        var user=_userRepository.GetByEmail(email);
        if(user==null){
            throw new Exception("User not found");

        }
        if(user.password!=password){
            throw new Exception("Invalid password");
        }

        return new Response<string>(message: "successfully logged" , data: generateToken(user));

       


     }




        public string generateToken(User user){
       var tokenHandler = new JwtSecurityTokenHandler();
       var key =Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
       var tokenDescriptor = new SecurityTokenDescriptor
       {
        Subject = new ClaimsIdentity(new Claim[]{
            new Claim("email", user.email),
            new Claim("userId", user.id.ToString()),
        }),
        Expires = DateTime.UtcNow.AddHours(1),
        Issuer = _configuration["Jwt:Issuer"],
        Audience = _configuration["Jwt:Audience"],
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
       };
       var token = tokenHandler.CreateToken(tokenDescriptor);
       return tokenHandler.WriteToken(token);
        }


    }
}