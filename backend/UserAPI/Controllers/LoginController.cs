using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.Requests;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Singnin(LoginRequest request)
        {
            Result result = _loginService.Singnin(request);
            if (result.IsFailed) return Unauthorized();
            return Ok();
        }
    }
}
