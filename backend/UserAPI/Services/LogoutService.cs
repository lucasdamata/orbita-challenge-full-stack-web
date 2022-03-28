using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;

namespace UserAPI.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result SignOut()
        {
            var resultIndentity = _signInManager.SignOutAsync();
            if (resultIndentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Failed Logout");
        }
    }
}
