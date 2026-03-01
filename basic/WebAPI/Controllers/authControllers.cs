using Microsoft.AspNetCore.Mvc;
using basic.Domain.Models;
using basic.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using basic.WebAPI.MiddleWare.Filters;
using basic.Application.Services;
namespace basic.WebAPI.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthControllers : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthControllers(IAuthService authService)
        {
            _authService = authService;
        }
        [ServiceFilter(typeof(GroupRoleAuthFilter))]
        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            if (user == null)
            {
                return BadRequest("User is required");
            }

            var result = _authService.Register(user);
            return Ok(result);
        }

        [HttpPost("addusertogroup")]
        public IActionResult AddUserToGroup( Usergroups userGroup)
        {
           
            var result = _authService.AddUserToGroup(userGroup.userId, userGroup.groupId);
            return Ok(result);
        }
        [HttpPost("addroletogroup")]
        public IActionResult AddRoleToGroup([FromBody] Grouproles groupRole)
        {
            
            var result = _authService.AddRoleToGroup(groupRole.groupId, groupRole.roleId);
            return Ok(result);
        }
        [HttpPost("addrole")]
        public IActionResult AddRole([FromBody] roles role)
        {
            var result = _authService.AddRole(role);
            return Ok(result);
        }

        [HttpPost("addgroup")]
        public IActionResult AddGroup(Groups group)
        {
            if (group == null)
            {
                return BadRequest("Group is required");
            }
            var result = _authService.AddGroup(group);
            return Ok(result);
        }


        [HttpGet("getusergroups")]
        public IActionResult GetUserGroups(int userId)
        {
            var result = _authService.getusergroups(userId);
            return Ok(result);
        }
        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var result = _authService.Login(email, password);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("getuseridfromtoken")]
        public IActionResult GetUserIdFromToken()
        {
            var userId = User.FindFirst("userId")?.Value;
            return Ok("userId: " + userId);  
        }
    }
}