using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Filters;
using basic.Application.Services;
using basic.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace basic.WebAPI.MiddleWare.Filters{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple=false,Inherited=true)]
public sealed class GroupRoleAuthFilter:ActionFilterAttribute{
    private readonly IAuthService _authService;
    private readonly IUserGroupsRepository _groupUserRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IGroupRolesRepository _groupRolesRepository;
    private readonly IUserPermissionRepository _userPermissionRepository;
    public GroupRoleAuthFilter(IAuthService authService, IUserGroupsRepository groupUserRepository, IGroupRepository groupRepository, IGroupRolesRepository groupRolesRepository, IUserPermissionRepository userPermissionRepository){
        _authService = authService;
        _groupUserRepository = groupUserRepository;
        _groupRepository = groupRepository;
        _groupRolesRepository = groupRolesRepository;
        _userPermissionRepository = userPermissionRepository;
    }

 public override void OnActionExecuting(ActionExecutingContext context){

if(!context.HttpContext.User.Identity.IsAuthenticated){
    context.Result = new UnauthorizedResult();
    return;
}

    var userId = context.HttpContext.User.FindFirst("userId")?.Value;

    var userGroups=_groupUserRepository.getUserGroups(int.Parse(userId));
    var groupRoles=_groupRolesRepository.getGroupRoles(userGroups.Select(x => x.groupId).Distinct().ToList());
    var groupIds = userGroups.Select(x => x.groupId).Distinct().ToList();
    var roleId =groupRoles.Select(x => x.roleId).Distinct().ToList();
    var controller=context.RouteData.Values["controller"].ToString();
    var action=context.RouteData.Values["action"].ToString();
    var requiredRoles=_userPermissionRepository.getUserPermissions( controller, action);
    var requiredRolesIds=requiredRoles.Select(x => x.roleId).Distinct().ToList();

    if(requiredRoles.Count==0){
        context.Result = new UnauthorizedResult();
        return;
    }

    if(userId ==null ){

 context.Result = new UnauthorizedResult();
    return;
    }
 if(userGroups ==null ){

 context.Result = new UnauthorizedResult();
    return;

    }

    if(groupRoles ==null ){

    context.Result = new UnauthorizedResult();
    return;

    }
    var hasAccess=requiredRolesIds.Any(x=>roleId.Contains(x));
if(!hasAccess){
    context.Result = new UnauthorizedResult();
    return;
}

   base.OnActionExecuting(context);

   
    }
public override void OnActionExecuted(ActionExecutedContext context){}
}


}