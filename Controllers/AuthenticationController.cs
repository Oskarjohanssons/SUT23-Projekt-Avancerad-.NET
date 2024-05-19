using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_Projekt___Avancerad_.NET.Dto.Requests;
using SUT23_Projekt___Avancerad_.NET.Services;

namespace SUT23_Projekt___Avancerad_.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IAuthenticationRepository authenticationRepository, IUserRepository userRepository)
        {

            _authenticationRepository = authenticationRepository;
            _userRepository = userRepository;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin login)
        {
            if (_authenticationRepository.ValidateLogin(login.Username, login.Password))
            {
                var user = _userRepository.FindByUsername(login.Username);
                var token = _authenticationRepository.GenerateJwtToken(user);
                return Ok(new { token = token });
            }
            return Unauthorized();
        }
    }
}
