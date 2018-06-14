using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using My.Project.Authorization;
using My.Project.Roles;
using My.Project.WebMpa.Models.Roles;

namespace My.Project.WebMpa.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Sys_Roles)]
    public class RolesController : ProjectControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        public RolesController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }


        //public async Task<ActionResult> Index()
        //{
        //    var roles = (await _roleAppService.GetAll(new PagedAndSortedResultRequestDto())).Items;
        //    var permissions = (await _roleAppService.GetAllPermissions()).Items;
        //    var model = new RoleListViewModel
        //    {
        //        Roles = roles,
        //        Permissions = permissions
        //    };

        //    return View(model);
        //}

        //public async Task<ActionResult> EditRoleModal(int roleId)
        //{
        //    var role = await _roleAppService.Get(new EntityDto(roleId));
        //    var permissions = (await _roleAppService.GetAllPermissions()).Items;
        //    var model = new EditRoleModalViewModel
        //    {
        //        Role = role,
        //        Permissions = permissions
        //    };
        //    return View("_EditRoleModal", model);
        //}
    }
}