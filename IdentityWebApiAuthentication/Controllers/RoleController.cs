using IdentityWebApiAuthentication.Model;
using IdentityWebApiAuthentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IdentityWebApiAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public IRoleService _roleService { get; }
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRole()
        {
            var list = await _roleService.GetRolesAsync(); ;
            return Ok(list);
        }


        [Authorize(Roles = "admin,user")]
        [HttpGet]
        public async Task<IActionResult> GetUserRole(string userEmail)
        {
            var userClaim = await _roleService.GetUserRolesAsync(userEmail);
            return Ok(userClaim);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("addRoles")]
        public async Task<IActionResult> AddRole(string[] roles)
        {
            var userRole = await _roleService.AddRolesAsync(roles);
            if (userRole.Count == 0)
            {
                return BadRequest();
            }
            return Ok(userRole);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("addUserRoles")]
        public async Task<IActionResult> AddUserRole([FromBody] AddUserMode addUser)
        {
            var result = await _roleService.AddUserRolesAsync(addUser.UserEmail, addUser.Roles);

            if (!result)
            {
                return BadRequest();
            }
            return StatusCode((int)HttpStatusCode.Created, result);
        }
    }
    //video start 34.50
}
