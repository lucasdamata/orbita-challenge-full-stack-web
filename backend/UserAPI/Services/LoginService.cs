using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using UserAPI.Data.Requests;

namespace UserAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signManager;

        public LoginService(SignInManager<IdentityUser<int>> signManager)
        {
            _signManager = signManager;
        }

        public Result Singnin(LoginRequest request)
        {
            var resultIdentity = _signManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Faild Login");
        }
    }
}
