using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private RegisterService _registerUser;

        public RegisterController(RegisterService registerUser)
        {
            _registerUser = registerUser;
        }

        [HttpPost]
        public IActionResult Store(CreateUserDTO userDTO)
        {
            Result result = _registerUser.Create(userDTO);
            if (result.IsFailed) return StatusCode(500);
            return Ok();
        }
    }
}
