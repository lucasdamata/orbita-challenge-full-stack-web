using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using UserAPI.Data.Requests;
using System.Linq;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signManager, TokenService tokenService)
        {
            _signManager = signManager;
            _tokenService = tokenService;
        }

        public Result SignIn(LoginRequest request)
        {
            var resultIdentity = _signManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultIdentity.Result.Succeeded)
            {
                var identityUser = _signManager
                    .UserManager
                    .Users
                    .FirstOrDefault(user => 
                        user.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.Create(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            };
            return Result.Fail("Faild Login");
        }
    }
}
