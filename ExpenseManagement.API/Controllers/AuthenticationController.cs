using ExpenseManagement.Domain.DTOs;
using ExpenseManagement.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExpenseManagement.API.Controllers
{
    [Controller]
    [Route("api/v1/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDTO loginDTO)
        {
            try
            {
                var response = await _authenticationService.Login(loginDTO);
                return Ok(response);
            }
            catch (AccessViolationException accEx)
            {
                return BadRequest(accEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add-user")]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddUser([FromBody] UserDTO userDTO)
        {
            try
            {
                var response = await _authenticationService.AddUser(userDTO);
                return Created("", response);
            }
            catch (MissingFieldException mFEx)
            {
                return BadRequest(mFEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
