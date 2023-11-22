using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Services.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Managment_System.Core.Models;
using Task_Managment_System.Server.Models;

namespace Roles.Controllers
{
    /// <summary>
    /// Manages roles within the system. This controller is only accessible by Admin users.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleManagerService _roleManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesController"/> class.
        /// </summary>
        /// <param name="roleManager">The role manager service.</param>
        public RolesController(IRoleManagerService roleManager)
        {
            _roleManager = roleManager;
        }

        /// <summary>
        /// Retrieves all roles within the system.
        /// </summary>
        /// <returns>A list of all roles.</returns>
        [HttpGet("GetAll Roles")]
        public async Task<IActionResult> GetAllRules()
        {
            return Ok(_roleManager.GetAllRules());
        }

        /// <summary>
        /// Creates a new role within the system.
        /// </summary>
        /// <param name="roleModel">The details of the role to create.</param>
        /// <returns>The result of the role creation operation.</returns>
        [HttpPost("Create role")]
        public async Task<IActionResult> CreateRole(RoleModel roleModel)
        {
            var result = await _roleManager.CreateRole(roleModel);
            return Ok(result);
        }

        /// <summary>
        /// Assigns a role to a user.
        /// </summary>
        /// <param name="assigneRole">The user and role details.</param>
        /// <returns>The result of the role assignment operation.</returns>
        [HttpPost("Assigne role")]
        public async Task<IActionResult> AssigneRole(AssigneRole assigneRole)
        {
            await _roleManager.AssigneRole(assigneRole);
            return Ok();
        }

        /// <summary>
        /// Removes a role from a user.
        /// </summary>
        /// <param name="updateUserRole">The user and role details.</param>
        /// <returns>The result of the role removal operation.</returns>
        [HttpDelete("Remove role")]
        public async Task<IActionResult> RemoveUserRole(UpdateUserRoleModel updateUserRole)
        {
            await _roleManager.DeleteRole(updateUserRole);
            return Ok();
        }

        /// <summary>
        /// Updates the role assigned to a user.
        /// </summary>
        /// <param name="updateUserRole">The new user and role details.</param>
        /// <returns>The result of the role update operation.</returns>
        [HttpPut("Update user role")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleModel updateUserRole)
        {
            await _roleManager.UpdateUserRole(updateUserRole);
            return Ok();
        }
    }

}
