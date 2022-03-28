using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Signout()
        {
           Result result = _logoutService.SignOut();
           if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }
    }
}
