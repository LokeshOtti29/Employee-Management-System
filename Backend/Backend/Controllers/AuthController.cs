using Backend.Dtos.Inputs;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Users>> Register(CreateUserPayload payload)
        {
            var user = await _authServices.Register(payload);
            if(user is null)
            {
                return BadRequest("Username Already Exists");
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<String>> Login(LoginDto payload)
        {
            var isLogged = await _authServices.Login(payload);
            if(isLogged is null)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok(isLogged);
        }
    }
}
