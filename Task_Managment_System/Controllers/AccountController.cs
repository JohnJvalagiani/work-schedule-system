using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task_Managment_System.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Managment_System.Abstraction;
using Dtos;
using Task_Managment_System.Core.Models;
using Core.Responses;
using Microsoft.AspNetCore.Http;

namespace Task_Managment_System.Server.Controllers
{

    /// <summary>
    /// AccountController is responsible for user account activities such as registration, login, and deletion.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _service;
        private readonly ILogger<AccountController> _logger;
        private readonly CurrentUserSupplier _currentUserSupplier;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="currentUserSupplier">Supplies the current user's details.</param>
        /// <param name="service">The identity service.</param>
        /// <param name="logger">The logger.</param>
        public AccountController(CurrentUserSupplier currentUserSupplier, IIdentityService service,
            ILogger<AccountController> logger)
        {
            _service = service;
            _logger = logger;
            _currentUserSupplier = currentUserSupplier;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="User">The user to register.</param>
        /// <returns>A response indicating the result of the registration.</returns>
        [AllowAnonymous]
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserWrite User)
        {
            _logger.LogInformation("Registration", User);
            return Ok(await _service.Registration(User, User.Password));
        }

        /// <summary>
        /// Logs a user in.
        /// </summary>
        /// <param name="User">The login details.</param>
        /// <returns>A response containing the authentication result.</returns>
        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthentificationResult))]
        public async Task<ActionResult<AuthentificationResult>> Login([FromBody] LoginDto User)
        {
            _logger.LogInformation("Login", User);
            var result = await _service.Login(User);
            if (result.Success)
            {
                return Ok(result);
            }
            return Unauthorized();
        }

        /// <summary>
        /// Deletes the current user's account.
        /// </summary>
        /// <returns>A response indicating the result of the deletion.</returns>
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete()
        {
            var curUser = await _currentUserSupplier.GetCurrentUser();
            _logger.LogInformation("Delete", curUser);
            return Ok(await _service.Delete(curUser.Id));
        }

        /// <summary>
        /// Updates the current user's details.
        /// </summary>
        /// <param name="userDto">The new user details.</param>
        /// <returns>A response indicating the result of the update.</returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UserRead userDto)
        {
            _logger.LogInformation("Update", userDto);
            return Ok(await _service.Update(userDto));
        }
    }

}
