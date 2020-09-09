using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsApi.Models;
using StudentsApi.Services;

namespace StudentsApi.Controllers
{
    /// <summary>
    /// Authentication operation controller. Here should be much more endpoints including create, delete accounts and password recovery and etc...
    /// </summary>
    [ApiController]
    [Route("")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtBearerAuthenticationService _jwtBearerAuthenticationService;

        public AuthenticationController(IJwtBearerAuthenticationService jwtBearerAuthenticationService)
        {
            _jwtBearerAuthenticationService = jwtBearerAuthenticationService;
        }

        /// <summary>
        /// Bearer authentication endpoint
        /// </summary>
        /// <param name="model">Authentication request model</param>
        /// <returns>Success</returns>
        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _jwtBearerAuthenticationService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(await Task.FromResult(user));
        }
    }
}
